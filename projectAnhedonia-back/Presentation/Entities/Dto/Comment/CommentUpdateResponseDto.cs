using projectAnhedonia_back.Domain.Entities.Dto.Comment;

namespace projectAnhedonia_back.Presentation.Entities.Dto.Comment
{
    public class CommentUpdateResponseDto
    {
        public string Content { get; set; }

        public long CommentId { get; set; }
    }

    public static partial class Mapper
    {
        public static CommentUpdateDto ConvertToDomainLayer(this CommentUpdateResponseDto data, long uid)
        {
            return new CommentUpdateDto(
                uid,
                data.CommentId,
                data.Content
            );
        }
    }
}