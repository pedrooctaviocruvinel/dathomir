CC      = gcc
CFLAGS  = -Wall -Wextra -I./include -std=c11

BINDIR  = bin
SOURCES = $(wildcard src/*.c)

ifeq ($(OS),Windows_NT)
    TARGET = $(BINDIR)/portal-worker.exe
    MKDIR  = mkdir $(BINDIR)
    RM     = if exist $(BINDIR) rmdir /s /q $(BINDIR)
    RUN    = $(BINDIR)\portal-worker.exe
else
    TARGET = $(BINDIR)/portal-worker
    MKDIR  = mkdir -p $(BINDIR)
    RM     = rm -rf $(BINDIR)
    RUN    = ./$(TARGET)
endif

all: $(TARGET)

$(TARGET): $(SOURCES) | $(BINDIR)
	$(CC) $(CFLAGS) $(SOURCES) -o $(TARGET)

$(BINDIR):
	$(MKDIR)

run: all
	$(RUN)

clean:
	$(RM)

.PHONY: all run clean
