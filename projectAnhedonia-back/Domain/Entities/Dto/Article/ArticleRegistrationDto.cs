namespace projectAnhedonia_back.Domain.Entities.Dto.Article
{
    public record ArticleRegistrationDto(
        string Title,
        long AuthorId,  // TODO change it to token or something else that we get after registration complete,
        string Content
    );
}