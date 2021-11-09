using System;
using System.Collections.Generic;
using projectAnhedonia_back.Domain.Entities.Dto.Article;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Article
{
    public class ArticleViewResponseDto
    {
        public string Title { get; set; }

        public long? AuthorId { get; set; }

        public string Content { get; set; }
        
        public IEnumerable<long> Comments { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
    
    public static partial class Mapper
    {
        public static ArticleViewResponseDto ConvertToPresentationLayer(this ArticleViewDto articleView)
        {
            return new ArticleViewResponseDto
            {
                Title = articleView.Title,
                Content = articleView.Content,
                AuthorId = articleView.AuthorId,
                CreationDateTime = articleView.CreationDateTime,
                Comments = articleView.Comments
            };
        }
    }
}