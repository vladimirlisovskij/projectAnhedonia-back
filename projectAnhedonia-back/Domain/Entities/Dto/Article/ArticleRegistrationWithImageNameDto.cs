namespace projectAnhedonia_back.Domain.Entities.Dto.Article
{
    public record ArticleRegistrationWithImageNameDto(
        string Title,
        long AuthorId,
        string Content
    );
}