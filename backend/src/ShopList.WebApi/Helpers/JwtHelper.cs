using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ShopList.WebApi.Models;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;

namespace ShopList.WebApi.Helpers
{
  public class JwtHelper
  {
    public static string GenerateAccessToken(IConfiguration configuration, string role)
    {
      TokenOption tokenOption = configuration.GetSection("TokenOption").Get<TokenOption>();
      List<Claim> claims = new List<Claim>();
      claims.Add(new Claim(ClaimTypes.Role, role));

      JwtSecurityToken token = new JwtSecurityToken(
        claims: claims,
        issuer: tokenOption.Issuer,
        audience: tokenOption.Audience,
        notBefore: DateTime.Now,
        expires: DateTime.Now.AddHours(tokenOption.Expiration),
        signingCredentials: new SigningCredentials(
          new SymmetricSecurityKey(Convert.FromBase64String(tokenOption.Key)),
          SecurityAlgorithms.HmacSha256
        )
      );
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}