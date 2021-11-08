namespace projectAnhedonia_back.Domain.Entities.Dto.User
{
    public record UserUpdateDto(
        long Id,
        string Username,
        string About
    );
}