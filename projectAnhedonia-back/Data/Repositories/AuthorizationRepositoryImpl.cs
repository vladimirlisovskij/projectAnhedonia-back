using projectAnhedonia_back.Data.Models.Authorization;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Data.Repositories
{
    public class AuthorizationRepositoryImpl : IAuthorizationRepository
    {
        private readonly AuthorizationService _service;

        public AuthorizationRepositoryImpl(AuthorizationService service)
        {
            _service = service;
        }

        public long GetUserIdFromBearer(string bearer)
        {
            return _service.GetUserIdFromBearer(bearer);
        }

        public string CreateBearerForUser(long id)
        {
            return _service.CreateBearerWithUserId(id);
        }
    }
}