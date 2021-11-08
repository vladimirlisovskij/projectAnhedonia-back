using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Presentation.Entities.Dto.User
{
    public class UserChangePasswordRequestDto
    {
        public string Password { get; set; }
    }

    public static partial class Mapper
    {
        public static UserChangePasswordDto ConvertToDomainLayer(this UserChangePasswordRequestDto userProfileDto, long uid)
        {
            return new UserChangePasswordDto(
                uid,
                userProfileDto.Password
            );
        }
    }
}