using Microsoft.AspNetCore.Http;

namespace projectAnhedonia_back.Domain.Entities.Dto.Article
{
    public record ArticleRegistrationWithRawImageDto(
        string Title,
        long AuthorId,
        string Content,
        IFormFile Image
    );

    public static partial class Mapper
    {
        public static ArticleRegistrationWithImageNameDto ConvertToImageName(this ArticleRegistrationWithRawImageDto data)
        {
            return new ArticleRegistrationWithImageNameDto(
                data.Title,
                data.AuthorId,
                data.Content
            );
        }
    }
}