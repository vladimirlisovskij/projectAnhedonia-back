using System;
using projectAnhedonia_back.Domain.Entities.Dto.Comment;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto.Database
{
    public sealed class Comment
    {
        public long Id { get; set; }
        public long? AuthorId { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public DateTime CreationDateTime { get; set; }

        public User Author { get; set; }
        
        public Post Post { get; set; }
    }

    public static partial class Mapper
    {
        public static Comment ConvertToDataLayer(this CommentCreateDto data)
        {
            return new Comment
            {
                PostId = data.PostId,
                AuthorId = data.AuthorId,
                Content = data.Content,
                CreationDateTime = DateTime.Now,
            };
        }
        
        public static Comment ConvertToDataLayer(this CommentUpdateDto data)
        {
            return new Comment
            {
                AuthorId = data.AuthorId,
                Content = data.Content,
                Id = data.CommentId
            };
        }
        
        public static CommentViewDto ConvertToDomainLayer(this Comment data)
        {
            return new CommentViewDto(
                data.AuthorId,
                data.Content,
                data.CreationDateTime
            );
        }
    }
}