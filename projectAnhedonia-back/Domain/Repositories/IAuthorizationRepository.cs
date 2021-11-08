namespace projectAnhedonia_back.Domain.Repositories
{
    public interface IAuthorizationRepository
    {
        public long GetUserIdFromBearer(string bearer);

        public string CreateBearerForUser(long id);
    }
}