package com.dathomir.portal.infrastructure.data.repositories;

import com.dathomir.portal.infrastructure.data.entities.JpaAuthor;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.UUID;

public interface JpaAuthorRepository extends JpaRepository<JpaAuthor, UUID> {
}
