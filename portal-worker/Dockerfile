FROM gcc:14-bookworm AS build

RUN apt-get update \
    && apt-get install -y --no-install-recommends librdkafka-dev libcjson-dev \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY Makefile .
COPY include ./include
COPY src ./src

RUN make

FROM debian:bookworm-slim

RUN apt-get update \
    && apt-get install -y --no-install-recommends librdkafka1 libcjson1 \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=build /app/bin/portal-worker .

CMD ["./portal-worker"]