using System;
using System.Collections.Generic;
using projectAnhedonia_back.Data.Common;
using projectAnhedonia_back.Domain.Entities.Dto.User;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto.Database
{
    public sealed class User
    {
        private string _password;

        public long Id { get; set; }

        public string Username { get; set; }

        public string Password
        {
            get => _password;
            set => _password = Tools.sha256_hash(value);
        }

        public void SetShaPassword(string shaPassword)
        {
            _password = shaPassword;
        }

        public string About { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Coauthor> CoauthorsRecords { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }

        public User()
        {
            CoauthorsRecords = new HashSet<Coauthor>();
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }
    }

    public static partial class Mapper
    {
        public static User ConvertToDataLayer(this UserRegistrationDto userRegistrationDto)
        {
            return new User
            {
                Username = userRegistrationDto.Username,
                Password = userRegistrationDto.Password,
                RegistrationDate = DateTime.Now,
            };
        }
        public static User ConvertToDataLayer(this UserUpdateDto userRegistrationDto)
        {
            return new User
            {
                Username = userRegistrationDto.Username,
                Id = userRegistrationDto.Id,
                About = userRegistrationDto.About
            };
        }
        
        public static User ConvertToDataLayer(this UserChangePasswordDto userRegistrationDto)
        {
            return new User
            {
                Id = userRegistrationDto.Id,
                Password = userRegistrationDto.Password
            };
        }
    }
}