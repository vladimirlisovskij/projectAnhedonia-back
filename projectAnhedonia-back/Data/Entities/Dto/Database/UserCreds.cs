using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Data.Entities.Dto.Database
{
    public class UserCreds
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    public static partial class Mapper
    {
        public static UserCreds ConvertToDataLayer(this UserCredsDto creds)
        {
            return new UserCreds
            {
                Username = creds.Username,
                Password = creds.Password
            };
        }
    }
}