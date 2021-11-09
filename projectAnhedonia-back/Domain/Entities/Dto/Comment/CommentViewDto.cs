using System;

namespace projectAnhedonia_back.Domain.Entities.Dto.Comment
{
    public record CommentViewDto(
        long? AuthorId,
        string Content,
        DateTime CreationDateTime
    );
}