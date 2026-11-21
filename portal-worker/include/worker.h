#pragma once

#include <pthread.h>
#include <cJSON.h>

typedef void (*TopicHandler)(const cJSON *json);

typedef struct
{
    const char *topic;
    TopicHandler handler;
    pthread_t thread;
} Worker;

void *worker_run(void *arg);
void worker_stop(void);
