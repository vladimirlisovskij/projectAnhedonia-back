namespace projectAnhedonia_back.Domain.Entities.Dto.Comment
{
    public record CommentCreateDto(
        long AuthorId,
        string Content,
        long PostId
    );
}