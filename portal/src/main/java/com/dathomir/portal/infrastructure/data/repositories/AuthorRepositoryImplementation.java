package com.dathomir.portal.infrastructure.data.repositories;

import com.dathomir.portal.application.repositories.AuthorRepository;
import com.dathomir.portal.domain.entities.Author;
import com.dathomir.portal.infrastructure.data.entities.JpaAuthor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class AuthorRepositoryImplementation implements AuthorRepository {

    @Autowired
    private JpaAuthorRepository jpaAuthorRepository;

    @Override
    public List<Author> findAll() {
        return jpaAuthorRepository
                .findAll()
                .stream()
                .map(JpaAuthor::Map)
                .toList();
    }

    @Override
    public void save(Author author) {
        jpaAuthorRepository.save(new JpaAuthor(author));
    }
}
