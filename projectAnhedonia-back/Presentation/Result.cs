namespace projectAnhedonia_back.Presentation
{
    public record Result<T>(string Status, string Message, T Data);
}