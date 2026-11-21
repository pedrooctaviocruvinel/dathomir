CC      = gcc
CFLAGS  = -Wall -Wextra -std=c11 -I./include -I/usr/include/cjson
LDLIBS  = -lrdkafka -lcjson

BINDIR  = bin
TARGET  = $(BINDIR)/portal-worker
SOURCES = $(wildcard src/*.c)

all: $(TARGET)

$(TARGET): $(SOURCES) | $(BINDIR)
	$(CC) $(CFLAGS) $(SOURCES) -o $(TARGET) $(LDLIBS)

$(BINDIR):
	mkdir -p $(BINDIR)

run: all
	./$(TARGET)

clean:
	rm -rf $(BINDIR)

.PHONY: all run clean
