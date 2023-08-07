
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OSBackend.Application.Abstractions.Token;
using OSBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {

        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute, Guid userId)  //parametre olarak userId al, controllerdan çek, tokena at(?)...
        {
            Application.DTOs.Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"])); //Security key simetriğini alıyor.

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256); // Security key şifrelendi. - "HmacSha256" algoritmalar içinden seçilen bir algoritmadır. Başkası da seçilebilirdi.

            token.Expiration = DateTime.UtcNow.AddMinutes(minute);  //Token üretilme fnc. çağırılırken (Itokenhandlerdaki CreateAccessToken) içerisine dakika parametresi alacak.

            JwtSecurityToken securityToken = new(

                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                claims: new List<Claim> { new Claim("user id", userId.ToString()) },
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken= tokenHandler.WriteToken(securityToken);

            return token;


        }
    }
}
