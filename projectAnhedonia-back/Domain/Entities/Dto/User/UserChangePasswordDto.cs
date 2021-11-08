namespace projectAnhedonia_back.Domain.Entities.Dto.User
{
    public record UserChangePasswordDto(
        long Id,
        string Password
    );
}