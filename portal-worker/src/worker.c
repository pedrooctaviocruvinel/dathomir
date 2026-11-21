#include <pthread.h>
#include <signal.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <librdkafka/rdkafka.h>
#include <cJSON.h>

#include "handlers.h"
#include "worker.h"

static volatile sig_atomic_t running = 1;

void worker_stop(void)
{
    running = 0;
}

static rd_kafka_t *create_consumer(const char *brokers, const char *topic)
{
    char errstr[512];
    char group_id[256];

    snprintf(group_id, sizeof group_id, "portal-worker-%s", topic);

    rd_kafka_conf_t *conf = rd_kafka_conf_new();

    if (rd_kafka_conf_set(conf, "bootstrap.servers", brokers, errstr, sizeof errstr) != RD_KAFKA_CONF_OK ||
        rd_kafka_conf_set(conf, "group.id", group_id, errstr, sizeof errstr) != RD_KAFKA_CONF_OK ||
        rd_kafka_conf_set(conf, "auto.offset.reset", "earliest", errstr, sizeof errstr) != RD_KAFKA_CONF_OK)
    {
        fprintf(stderr, "[%s] config error: %s\n", topic, errstr);

        rd_kafka_conf_destroy(conf);

        return NULL;
    }

    rd_kafka_t *consumer = rd_kafka_new(RD_KAFKA_CONSUMER, conf, errstr, sizeof errstr);

    if (consumer == NULL)
    {
        fprintf(stderr, "[%s] failed to create consumer: %s\n", topic, errstr);

        return NULL;
    }

    rd_kafka_poll_set_consumer(consumer);

    rd_kafka_topic_partition_list_t *topics = rd_kafka_topic_partition_list_new(1);
    rd_kafka_topic_partition_list_add(topics, topic, RD_KAFKA_PARTITION_UA);

    rd_kafka_resp_err_t err = rd_kafka_subscribe(consumer, topics);

    rd_kafka_topic_partition_list_destroy(topics);

    if (err != RD_KAFKA_RESP_ERR_NO_ERROR)
    {
        fprintf(stderr, "[%s] failed to subscribe: %s\n", topic, rd_kafka_err2str(err));

        rd_kafka_destroy(consumer);

        return NULL;
    }

    return consumer;
}

void *worker_run(void *arg)
{
    const char *brokers = getenv("KAFKA_BOOTSTRAP_SERVERS");

    if (brokers == NULL)
        brokers = "localhost:9092";

    Worker *worker = arg;
    rd_kafka_t *consumer = create_consumer(brokers, worker->topic);

    if (consumer == NULL)
    {
        return NULL;
    }

    printf("[%s] subscribed on %s, waiting for messages\n", worker->topic, brokers);

    while (running)
    {
        rd_kafka_message_t *msg = rd_kafka_consumer_poll(consumer, 1000);

        if (msg == NULL)
        {
            continue;
        }

        if (msg->err != RD_KAFKA_RESP_ERR_NO_ERROR)
        {
            fprintf(stderr, "[%s] consumer error: %s\n", worker->topic, rd_kafka_message_errstr(msg));

            rd_kafka_message_destroy(msg);

            continue;
        }

        cJSON *json = cJSON_ParseWithLength(msg->payload, msg->len);

        if (json == NULL)
        {
            fprintf(stderr, "[%s] invalid JSON at offset %lld\n", worker->topic, (long long)msg->offset);
        }
        else
        {
            worker->handler(json);

            cJSON_Delete(json);
        }

        rd_kafka_message_destroy(msg);
    }

    printf("[%s] shutting down\n", worker->topic);

    rd_kafka_consumer_close(consumer);
    rd_kafka_destroy(consumer);

    return NULL;
}
