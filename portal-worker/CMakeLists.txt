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

target_link_libraries(portal-worker
    PRIVATE rdkafka
)
