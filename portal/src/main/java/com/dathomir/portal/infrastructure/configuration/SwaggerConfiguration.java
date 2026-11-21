package com.dathomir.portal.infrastructure.configuration;

import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Contact;
import io.swagger.v3.oas.models.info.Info;
import io.swagger.v3.oas.models.info.License;
import org.springdoc.core.models.GroupedOpenApi;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class SwaggerConfiguration {

    @Bean
    public GroupedOpenApi publicApi() {
        return GroupedOpenApi
                .builder()
                .group("portal")
                .pathsToMatch("/**")
                .build();
    }

    @Bean
    public OpenAPI customOpenAPI() {
        return new OpenAPI()
                .info(new Info()
                        .title("Portal API")
                        .description("Portal API of Dathomir.")
                        .contact(new Contact()
                                .name("Pedro Octávio Cruvinel Almeida")
                                .email("pedrooctaviocruvinel@gmail.com")
                                .url("https://github.com/pedrooctaviocruvinel"))
                        .license(new License()
                                .name("MIT")
                                .url("https://github.com/pedrooctaviocruvinel/dathomir/blob/main/LICENSE"))
                        .version("1.0"));
    }

}
