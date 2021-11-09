using System;
using System.Collections.Generic;
using projectAnhedonia_back.Data.Entities.Dto.Database;
using projectAnhedonia_back.Domain.Entities.Dto.Article;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto
{
    public sealed class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public long? PreviewImageId { get; set; }

        public User Author { get; set; }
        public Image PreviewImage { get; set; }
        public ICollection<Coauthor> Coauthors { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Coauthors = new HashSet<Coauthor>();
            Comments = new HashSet<Comment>();
        }
    }
    
    public static partial class Mapper
    {
        public static Post ConvertToDataLayer(this ArticleRegistrationDto data)
        {
            return new Post
            {
                Title = data.Title,
                AuthorId = data.AuthorId,
                Content = data.Content,
                CreationDateTime = DateTime.Now,
            };
        }
        
        public static Post ConvertToDataLayer(this ArticleUpdateDto data)
        {
            return new Post
            {
                Title = data.Title,
                AuthorId = data.AuthorId,
                Id = data.ArticleId,
                Content = data.Content,
            };
        }
    }
}