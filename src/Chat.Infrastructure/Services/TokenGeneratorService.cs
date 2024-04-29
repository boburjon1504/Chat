﻿using Chat.Application.Common.Settings;
using Chat.Application.Interfaces;
using Chat.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chat.Infrastructure.Services;
public class TokenGeneratorService(IOptions<JwtSettings> jwtSettings) : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public string GenerateToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }

    private JwtSecurityToken GetJwtToken(User user)
    {
        var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credential = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);
        var claims = GetClaims(user);
        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credential
            );
    }

    private List<Claim> GetClaims(User user) => new List<Claim>
    {
        new Claim("UserId",user.Id.ToString()),
        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
        new Claim(ClaimTypes.Email,user.Email),
    };
}
