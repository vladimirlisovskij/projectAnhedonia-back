using System;
using System.Collections.Generic;
using projectAnhedonia_back.Domain.Entities.Dto.User;

namespace projectAnhedonia_back.Presentation.Entities.Dto.User
{
    public class UserProfileResponseDto
    {
        public string Username { get; set; }
        public string About { get; set; }
        public DateTime RegistrationDate { get; set; }
        public IEnumerable<long> Articles { get; set; }
    }

    public static partial class Mapper
    {
        public static UserProfileResponseDto ConvertToPresentationLayer(this UserProfileDto userProfileDto)
        {
            return new UserProfileResponseDto
            {
                Username = userProfileDto.Username,
                About = userProfileDto.About,
                RegistrationDate = userProfileDto.RegistrationDate,
                Articles = userProfileDto.Articles
            };
        }
    }
}