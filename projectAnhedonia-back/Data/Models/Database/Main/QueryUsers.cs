using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext
    {
        public Task<int> AddUser(User user)
        {
            Users.Add(user);
            return SaveChangesAsync();
        }

        public Task<int> UpdateUser(User user)
        {
            var oldUser = Users.First(u => u.Id == user.Id);

            oldUser.Username = user.Username;
            oldUser.About = user.About;

            return SaveChangesAsync();
        }

        public Task<int> ChangeUserPassword(User user)
        {
            var oldUser = Users.First(u => u.Id == user.Id);

            oldUser.SetShaPassword(user.Password);

            return SaveChangesAsync();
        }

        public Task<int> RemoveUserById(long id)
        {
            Users.Remove(new User {Id = id});
            return SaveChangesAsync();
        }

        public Task<long> GetUserIdByCreds(UserCreds creds)
        {
            var userWithSha = new User {Username = creds.Username, Password = creds.Password};
            return Users.Where(u => u.Username == userWithSha.Username && u.Password == userWithSha.Password)
                .Select( u => u.Id)
                .FirstAsync();
        }

        public Task<List<UserProfile>> GetAllUsers()
        {
            return Users
                .Select(u => new UserProfile
                {
                    Username = u.Username,
                    About = u.About,
                    RegistrationDate = u.RegistrationDate,
                    Articles = u.Posts.Select(a => a.Id)
                })
                .ToListAsync();
        }

        public Task<UserProfile> GetUserById(long id)
        {
            return Users
                .Where(u => u.Id == id)
                .Select(u => new UserProfile
                {
                    Username = u.Username,
                    About = u.About,
                    RegistrationDate = u.RegistrationDate,
                    Articles = u.Posts.Select(a => a.Id)
                })
                .FirstAsync();
        }

        public Task<long> GetUserIdByUserName(string usename)
        {
            return Users
                .Where(u => u.Username == usename)
                .Select(u => u.Id)
                .FirstAsync();
        }
    }
}