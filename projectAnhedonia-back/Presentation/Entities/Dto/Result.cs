namespace projectAnhedonia_back.Presentation.Entities.Dto
{
    public record Result<T>(string Status, string Message, T Data);
    public record Result(string Status, string Message);
}