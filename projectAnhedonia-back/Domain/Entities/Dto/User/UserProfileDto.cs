using System;
using System.Collections.Generic;

namespace projectAnhedonia_back.Domain.Entities.Dto.User
{
    public record UserProfileDto(
        string Username,
        string About,
        DateTime RegistrationDate,
        IEnumerable<long> Articles
    );
}