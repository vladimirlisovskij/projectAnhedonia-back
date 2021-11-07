namespace projectAnhedonia_back.Domain.Entities.Dto.User
{
    public record UserRegistrationDto(
        string Username,
        string Password
    );
}