cmake_minimum_required(VERSION 3.20)

if(CMAKE_SCRIPT_MODE_FILE)
    set(_src ${CMAKE_CURRENT_LIST_DIR})
    set(_build ${_src}/build)
    execute_process(COMMAND ${CMAKE_COMMAND} -S ${_src} -B ${_build} -DCMAKE_BUILD_TYPE=Release
                    COMMAND_ERROR_IS_FATAL ANY)
    execute_process(COMMAND ${CMAKE_COMMAND} --build ${_build} --parallel
                    COMMAND_ERROR_IS_FATAL ANY)
    execute_process(COMMAND ${_build}/portal-worker
                    COMMAND_ERROR_IS_FATAL ANY)
    return()
endif()

project(portal-worker LANGUAGES C)

set(CMAKE_C_STANDARD 11)
set(CMAKE_C_STANDARD_REQUIRED ON)
set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

include(FetchContent)

FetchContent_Declare(cjson
    GIT_REPOSITORY https://github.com/DaveGamble/cJSON.git
    GIT_TAG v1.7.18
    SOURCE_SUBDIR do-not-add-subdirectory
)
FetchContent_MakeAvailable(cjson)

set(RDKAFKA_BUILD_STATIC ON CACHE BOOL "" FORCE)
set(RDKAFKA_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)
set(RDKAFKA_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(WITH_SSL OFF CACHE BOOL "" FORCE)
set(WITH_SASL OFF CACHE BOOL "" FORCE)
set(WITH_ZLIB OFF CACHE BOOL "" FORCE)
set(WITH_ZSTD OFF CACHE BOOL "" FORCE)
set(WITH_CURL OFF CACHE BOOL "" FORCE)
set(ENABLE_LZ4_EXT OFF CACHE BOOL "" FORCE)

FetchContent_Declare(librdkafka
    GIT_REPOSITORY https://github.com/confluentinc/librdkafka.git
    GIT_TAG v2.6.1
)
FetchContent_MakeAvailable(librdkafka)

configure_file(
    ${librdkafka_SOURCE_DIR}/src/rdkafka.h
    ${CMAKE_BINARY_DIR}/rdkafka-include/librdkafka/rdkafka.h
    COPYONLY
)

file(GLOB_RECURSE PROJECT_SOURCES CONFIGURE_DEPENDS
    "${CMAKE_CURRENT_SOURCE_DIR}/src/*.c"
)

add_executable(portal-worker
    ${PROJECT_SOURCES}
    ${cjson_SOURCE_DIR}/cJSON.c
)

target_include_directories(portal-worker
    PRIVATE include
    PRIVATE ${cjson_SOURCE_DIR}
    PRIVATE ${CMAKE_BINARY_DIR}/rdkafka-include
)

include(ExternalProject)

set(LIBPQ_PREFIX ${CMAKE_BINARY_DIR}/libpq)
file(MAKE_DIRECTORY ${LIBPQ_PREFIX}/include)

ExternalProject_Add(libpq_ext
    URL https://ftp.postgresql.org/pub/source/v16.16/postgresql-16.16.tar.gz
    URL_HASH SHA256=3e930f3366f675ab26e873d16201201f8e9b6d9bc13686e4465380271145ea2d
    DOWNLOAD_NO_EXTRACT TRUE
    BUILD_IN_SOURCE TRUE
    CONFIGURE_COMMAND tar xzf <DOWNLOADED_FILE> --strip-components=1
              COMMAND ./configure --prefix=${LIBPQ_PREFIX}
                      --without-readline --without-zlib --without-icu
    BUILD_COMMAND make -C src/backend generated-headers
          COMMAND make -C src/interfaces/libpq
    INSTALL_COMMAND make -C src/interfaces/libpq install
            COMMAND make -C src/include install
    BUILD_BYPRODUCTS ${LIBPQ_PREFIX}/lib/libpq.so
)

add_library(libpq SHARED IMPORTED)
set_target_properties(libpq PROPERTIES
    IMPORTED_LOCATION ${LIBPQ_PREFIX}/lib/libpq.so
    INTERFACE_INCLUDE_DIRECTORIES ${LIBPQ_PREFIX}/include
)
add_dependencies(portal-worker libpq_ext)

target_link_libraries(portal-worker
    PRIVATE rdkafka
    PRIVATE libpq
)
