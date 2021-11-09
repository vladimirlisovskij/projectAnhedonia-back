using System;
using System.Collections.Generic;
using projectAnhedonia_back.Domain.Entities.Dto.Article;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto.Database
{
    public sealed class PostView
    {
        public string Title { get; set; }
        public long? AuthorId { get; set; }
        public string Content { get; set; }

        public IEnumerable<long> Comments { get; set; }
        public IEnumerable<long> Coauthors { get; set; }
        
        public  string ImageName { get; set; }

        public DateTime CreationDateTime { get; set; }
        // public long? PreviewImageId { get; set; }
    }

    public static partial class Mapper
    {
        public static ArticleViewDto ConvertToDomainLayer(this PostView data)
        {
            return new ArticleViewDto(
                data.Title,
                data.AuthorId,
                data.Comments,
                data.Coauthors,
                data.ImageName,
                data.Content,
                data.CreationDateTime
            );
        }
    }
}