using projectAnhedonia_back.Domain.Entities.Dto.Comment;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Comment
{
    public class CommentCreateResponseDto
    {
        public string Content { get; set; }
        public long PostId { get; set; }
    }

    public static partial class Mapper
    {
        public static CommentCreateDto ConvertToDomainLayer(this CommentCreateResponseDto data, long uid)
        {
            return new CommentCreateDto(
                uid,
                data.Content,
                data.PostId
            );
        }
    }
}