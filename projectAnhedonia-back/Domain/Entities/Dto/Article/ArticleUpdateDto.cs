namespace projectAnhedonia_back.Domain.Entities.Dto.Article
{
    public record ArticleUpdateDto(
        string Title,
        long AuthorId,
        long ArticleId,
        string Content
    );
}