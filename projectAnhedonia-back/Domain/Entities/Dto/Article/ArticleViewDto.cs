﻿using System;

namespace projectAnhedonia_back.Domain.Entities.Dto.Article
{
    public record ArticleViewDto(
        string Title,
        long? AuthorId,
        // IEnumerable<long> Coauthors,
        string Content,
        DateTime CreationDateTime
        // TODO add comments and image
    );
}