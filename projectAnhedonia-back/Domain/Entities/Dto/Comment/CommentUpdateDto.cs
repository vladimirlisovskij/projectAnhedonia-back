namespace projectAnhedonia_back.Domain.Entities.Dto.Comment
{
    public record CommentUpdateDto(
        long AuthorId,
        long CommentId,
        string Content
    );
}