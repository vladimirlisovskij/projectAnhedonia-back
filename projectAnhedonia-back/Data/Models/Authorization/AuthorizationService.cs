using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using projectAnhedonia_back.Data.Common;
using projectAnhedonia_back.Data.Models.Database.Main;

namespace projectAnhedonia_back.Data.Models.Authorization
{
    public class AuthorizationService
    {
        private const string UserIdParam = "id";
        private const int TokenLifetimeDays = 7;

        public AuthorizationService(MainDatabaseContext databaseContext)
        {
        }
        
        public string CreateBearerWithUserId(long id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim(UserIdParam, id.ToString())}),
                Expires = DateTime.UtcNow.AddDays(TokenLifetimeDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public long GetUserIdFromBearer(string bearer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.SecretKey);
            tokenHandler.ValidateToken(bearer, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == UserIdParam).Value);
            return userId;
        }
    }
}