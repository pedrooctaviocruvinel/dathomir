#pragma once

#include <cJSON.h>

typedef struct
{
    char id[37];
    char name[101];
} Author;

void handle_author(const cJSON *json);
