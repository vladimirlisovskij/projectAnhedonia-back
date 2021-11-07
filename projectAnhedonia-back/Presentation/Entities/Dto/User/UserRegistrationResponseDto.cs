using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Presentation.Entities.Dto.User
{
    public class UserRegistrationRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static partial class Mapper
    {
        public static UserRegistrationDto ConvertToDomainLayer(this UserRegistrationRequestDto userProfileDto)
        {
            return new UserRegistrationDto(
                userProfileDto.Username,
                userProfileDto.Password
            );
        }
    }
}