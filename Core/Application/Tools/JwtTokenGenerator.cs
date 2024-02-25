using Application.Mediator.Results.AppUserResults;
using Application.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult results)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(results.Role))
			claims.Add(new Claim(ClaimTypes.Role, results.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, results.Id.ToString()));
			if (!string.IsNullOrWhiteSpace(results.Username))
				claims.Add(new Claim("Username", results.Username));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
			var signInCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
			var expiredDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
			JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDefault.ValidIssuer,audience:JwtTokenDefault.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:expiredDate,signingCredentials:signInCredentials);

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return new TokenResponseDto(handler.WriteToken(token),expiredDate);
		}
	}
}
