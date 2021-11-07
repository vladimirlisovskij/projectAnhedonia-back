using projectAnhedonia_back.Domain.Entities.Dto.Article;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Article
{
    public class ArticleRegistrationResponseDto
    {
        public string Title { get; set; }

        // TODO change it to token or something else that we get after registration complete
        public long AuthorId { get; set; }

        public string Content { get; set; }
    }

    public static partial class Mapper
    {
        public static ArticleRegistrationDto ConvertToDomainLayer(this ArticleRegistrationResponseDto articleRegistration)
        {
            return new ArticleRegistrationDto(
                articleRegistration.Title,
                articleRegistration.AuthorId,
                articleRegistration.Content
            );
        }
    }
}