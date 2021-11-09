﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using projectAnhedonia_back.Data.Entities.Dto.Database;
using projectAnhedonia_back.Domain.Entities.Dto;
using projectAnhedonia_back.Domain.Entities.Dto.User;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto
{
    public sealed class User
    {
        private string _password;

        public long Id { get; set; }

        public string Username { get; set; }

        public string Password
        {
            get => _password;
            set => _password = sha256_hash(value);
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

        private string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
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