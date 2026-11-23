package com.dathomir.portal.infrastructure.providers.kafka;

import com.dathomir.portal.application.repositories.AuthorRepository;
import com.dathomir.portal.domain.entities.Author;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.stereotype.Component;
import tools.jackson.databind.json.JsonMapper;

import java.util.UUID;

@Component
public class AuthorRegisteredEventConsumer {

    @Autowired
    private JsonMapper jsonMapper;

    @Autowired
    private AuthorRepository authorRepository;

    @KafkaListener(topics = "Authors", groupId = "${spring.kafka.consumer.group-id}")
    public void consume(String message) {
        var jsonNode = jsonMapper.readTree(message);

        var author = new Author(
                UUID.fromString(jsonNode.get("Id").asString()),
                jsonNode.get("Name").asString());

        authorRepository.save(author);
    }

}
