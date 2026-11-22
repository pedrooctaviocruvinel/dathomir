#include <stdio.h>
#include <cJSON.h>

#include "handlers.h"
#include "repository.h"

void handle_author(const cJSON *json)
{
    cJSON *id = cJSON_GetObjectItem(json, "Id");
    cJSON *name = cJSON_GetObjectItem(json, "Name");

    if (!cJSON_IsString(id) || !cJSON_IsString(name))
    {
        fprintf(stderr, "[Authors] invalid payload\n");

        return;
    }

    Author author;

    snprintf(author.id, sizeof author.id, "%s", id->valuestring);
    snprintf(author.name, sizeof author.name, "%s", name->valuestring);

    insert_author(&author);
}
