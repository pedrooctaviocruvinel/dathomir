package com.dathomir.portal.application.repositories;

import com.dathomir.portal.domain.entities.Author;

import java.util.List;

public interface AuthorRepository {

    List<Author> findAll();

    void save(Author author);

}
