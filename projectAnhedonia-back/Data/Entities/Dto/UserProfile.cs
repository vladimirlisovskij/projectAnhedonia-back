using System;
using System.Collections.Generic;
using projectAnhedonia_back.Domain.Entities.Dto;
using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Data.Entities.Dto
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string About { get; set; }
        public DateTime RegistrationDate { get; set; }
        public IEnumerable<long> Articles { get; set; }
    }

    public static partial class Mapper
    {
        public static UserProfileDto ConvertToDomainLayer(this UserProfile userRegistrationDto)
        {
            return new UserProfileDto(
                userRegistrationDto.Username,
                userRegistrationDto.About,
                userRegistrationDto.RegistrationDate,
                userRegistrationDto.Articles
            );
        }
    }
}