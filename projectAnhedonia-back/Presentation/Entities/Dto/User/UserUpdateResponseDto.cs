using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Presentation.Entities.Dto.User
{
    public class UserUpdateRequestDto
    {
        public string Username { get; set; }
        public string About { get; set; }
    }

    public static partial class Mapper
    {
        public static UserUpdateDto ConvertToDomainLayer(this UserUpdateRequestDto userProfileDto, long uid)
        {
            return new UserUpdateDto(
                uid,
                userProfileDto.Username,
                userProfileDto.About
            );
        }
    }
}