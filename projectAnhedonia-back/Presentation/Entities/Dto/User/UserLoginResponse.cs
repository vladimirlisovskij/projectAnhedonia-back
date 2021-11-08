using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Presentation.Entities.Dto.User
{
    public class UserLoginResponse
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public static partial class Mapper
    {
        public static UserCredsDto ConvertToPresentationLayer(this UserLoginResponse userProfileDto)
        {
            return new UserCredsDto(userProfileDto.Username, userProfileDto.Password);
        }
    }
}