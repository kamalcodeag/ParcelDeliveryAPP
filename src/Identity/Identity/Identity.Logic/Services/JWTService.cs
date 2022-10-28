using Identity.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Logic.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _cnfg;

        public JWTService(IConfiguration cnfg)
        {
            _cnfg = cnfg;
        }

        public string GenerateToken(IEnumerable<UserRolePermissionsModel> users)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            string issuer = _cnfg["Authentication:Jwt:Issuer"];
            string audience = _cnfg["Authentication:Jwt:Audience"];
            string subject = _cnfg["Authentication:Jwt:Subject"];
            string key = _cnfg["Authentication:Jwt:Key"];
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            DateTime expire = DateTime.UtcNow.AddHours(24);

            var user = users.FirstOrDefault();

            List<Claim> userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Surname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim("Phone", user.PhoneNumber),
                new Claim("Address", user.Address),
            };

            List<Claim> roleClaims = new List<Claim>();

            foreach (var item in users)
            {
                if(item.RoleName != null)
                {
                    roleClaims.Add(new Claim(ClaimTypes.Role, item.RoleName));
                }
            }

            List<Claim> permissionClaims = new List<Claim>();

            foreach (var item in users)
            {
                if(item.PermissionName != null)
                {
                    roleClaims.Add(new Claim(item.PermissionName, item.PermissionName));
                }
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, expire.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims)
            .Union(permissionClaims)
            .ToList();

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expire,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha512)
            );

            return tokenHandler.WriteToken(token);
        }
    }
}
