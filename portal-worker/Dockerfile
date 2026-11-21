FROM gcc:14 AS build
WORKDIR /app

COPY Makefile .
COPY include ./include
COPY src ./src

RUN make

FROM debian:bookworm-slim
WORKDIR /app

RUN useradd --system --no-create-home appuser
COPY --from=build /app/bin/portal-worker .
USER appuser

CMD ["./portal-worker"]
