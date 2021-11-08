﻿namespace projectAnhedonia_back.Domain.Entities.Dto.Article
{
    public record ArticleRegistrationDto(
        string Title,
        long AuthorId,
        string Content
    );
}