namespace projectAnhedonia_back.Domain.Entities.Dto.Image
{
    public record ImageUpdateDto(
        long AuthorId,
        long ArticleId,
        byte[] Image
    );
}