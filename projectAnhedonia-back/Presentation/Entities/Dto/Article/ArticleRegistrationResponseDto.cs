﻿using projectAnhedonia_back.Domain.Entities.Dto.Article;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Article
{
    public class ArticleRegistrationResponseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public static partial class Mapper
    {
        public static ArticleRegistrationDto ConvertToDomainLayer(
            this ArticleRegistrationResponseDto articleRegistration,
            long authorId
        )
        {
            return new ArticleRegistrationDto(
                articleRegistration.Title,
                authorId,
                articleRegistration.Content
            );
        }
    }
}