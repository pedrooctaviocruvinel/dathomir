#include <stdlib.h>
#include <signal.h>
#include <stdio.h>

#include "handlers.h"
#include "worker.h"

static Worker workers[] = {
    {"Authors", handle_author, 0}};

static const size_t workers_count = sizeof workers / sizeof workers[0];

static void on_signal(int sig)
{
    (void)sig;

    worker_stop();
}

int main(void)
{
    setvbuf(stdout, NULL, _IONBF, 0);

    signal(SIGINT, on_signal);
    signal(SIGTERM, on_signal);

    for (size_t i = 0; i < workers_count; i++)
    {
        if (pthread_create(&workers[i].thread, NULL, worker_run, &workers[i]) != 0)
        {
            fprintf(stderr, "[%s] failed to start thread\n", workers[i].topic);

            worker_stop();

            for (size_t j = 0; j < i; j++)
            {
                pthread_join(workers[j].thread, NULL);
            }

            return 1;
        }
    }

    printf("portal-worker started with %zu consumer(s)\n", workers_count);

    for (size_t i = 0; i < workers_count; i++)
    {
        pthread_join(workers[i].thread, NULL);
    }

    printf("portal-worker stopped\n");

    return 0;
}
