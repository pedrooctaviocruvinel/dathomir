CC      = gcc
CFLAGS  = -Wall -Wextra -I./include -std=c11

BINDIR  = bin
TARGET  = $(BINDIR)/portal-worker
SOURCES = $(wildcard ./src/*.c)

all: $(TARGET)

$(TARGET): $(SOURCES) | $(BINDIR)
	$(CC) $(CFLAGS) $(SOURCES) -o $(TARGET)

$(BINDIR):
	mkdir $(BINDIR)

run: all
	./$(TARGET)

clean:
	rm -rf $(BINDIR)
