package com.dathomir.portal.infrastructure.data.entities;

import com.dathomir.portal.domain.entities.Author;
import jakarta.persistence.*;

import java.util.UUID;

@Entity
@Table(name = "authors")
public class JpaAuthor {

    @Id
    private UUID id;

    @Column(nullable = false)
    private String name;

    public Author Map() {
        return new Author(this.id, name);
    }

    public JpaAuthor() {
    }

    public JpaAuthor(Author author) {
        id = author.getId();
        name = author.getName();
    }

    public UUID getId() {
        return id;
    }

    public String getName() {
        return name;
    }

}
