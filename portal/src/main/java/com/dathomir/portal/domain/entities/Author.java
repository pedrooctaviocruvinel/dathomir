package com.dathomir.portal.domain.entities;

import java.util.UUID;

public class Author {

    private final UUID id;

    private final String name;

    public Author(UUID id, String name) {
        this.id = id;
        this.name = name;
    }

    public UUID getId() {
        return id;
    }

    public String getName() {
        return name;
    }

}
