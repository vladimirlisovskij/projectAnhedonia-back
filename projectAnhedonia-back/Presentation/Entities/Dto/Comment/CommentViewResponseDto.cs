using System;
using projectAnhedonia_back.Domain.Entities.Dto.Comment;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Comment
{
    public class CommentViewResponseDto
    {
        public long? AuthorId { set; get; }
        public string Content { set; get; }
        public DateTime CreationDateTime { set; get; }
    }
    
    public static partial class Mapper
    {
        public static CommentViewResponseDto ConvertToPresentationLayer(this CommentViewDto data)
        {
            return new CommentViewResponseDto
            {
                AuthorId = data.AuthorId,
                Content = data.Content,
                CreationDateTime = data.CreationDateTime
            };
        }
    }
}