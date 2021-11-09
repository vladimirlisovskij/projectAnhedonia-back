using Microsoft.AspNetCore.Http;
using projectAnhedonia_back.Domain.Entities.Dto.Article;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Article
{
    public class ArticleUpdateResponseDto
    {
        public string Title { get; set; }
        public long Id { get; set; }
        public string Content { get; set; }
        
        public IFormFile Image { get; set; }
    }

    public static partial class Mapper
    {
        public static ArticleUpdateDto ConvertToDomainLayer(
            this ArticleUpdateResponseDto articleRegistration,
            long authorId
        )
        {
            return new ArticleUpdateDto(
                articleRegistration.Title,
                authorId,
                articleRegistration.Id,
                articleRegistration.Content
            );
        }
    }
}