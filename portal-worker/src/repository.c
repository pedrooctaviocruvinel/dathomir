#include <stdio.h>
#include <stdlib.h>
#include <libpq-fe.h>

#include "handlers.h"
#include "repository.h"

static PGconn *open_connection()
{
    const char *connectionstring = getenv("POSTGRESQL_CONNECTIONSTRING");

    PGconn *connection = PQconnectdb(connectionstring);

    if (PQstatus(connection) != CONNECTION_OK)
    {
        fprintf(stderr, "Connection failed: %s", PQerrorMessage(connection));

        PQfinish(connection);

        return NULL;
    }

    return connection;
}

static void close_connection(PGconn *connection)
{
    PQfinish(connection);

    return;
}

static int execute(PGconn *connection, const char *sql, const char *const *parameters, int number_parameters)
{
    PGresult *result = PQexecParams(connection, sql, number_parameters, NULL, parameters, NULL, NULL, 0);

    if (PQresultStatus(result) != PGRES_COMMAND_OK)
    {
        fprintf(stderr, "Command failed: %s", PQerrorMessage(connection));

        PQclear(result);

        return EXIT_FAILURE;
    }

    PQclear(result);

    return EXIT_SUCCESS;
}

int insert_author(Author *author)
{
    PGconn *connection = open_connection();

    const char *sql = "INSERT INTO authors (id, name) VALUES ($1::uuid, $2)";
    const char *params[2] = {author->id, author->name};

    int result = execute(connection, sql, params, 2);

    close_connection(connection);

    return result;
}
