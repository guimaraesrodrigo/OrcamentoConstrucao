using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPIOrcamento.ProviderJWT
{
    public class TokenJWTBuilder
    {
        private SecurityKey securityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";

        private Dictionary<string,string> claims = new Dictionary<string,string>(); 
        private int expiryInMinutes = 5;

        public TokenJWTBuilder AddSecutiryKey (SecurityKey _SecurityKey)
        {
            this.securityKey =  _SecurityKey;
            return this;
        }

        public TokenJWTBuilder AddSubject (string _subject)
        {
            this.subject =  _subject;
            return this;
        }

        public TokenJWTBuilder Addissuer (string _issuer)
        {
            this.issuer =  _issuer;
            return this;
        }

        public TokenJWTBuilder AddAudience (string _audience)
        {
            this.audience =  _audience;
            return this;
        }

         public TokenJWTBuilder AddExpireInMinutes (int _expiresInMinutes)
        {
            this.expiryInMinutes =  _expiresInMinutes;
            return this;
        }

         public TokenJWTBuilder AddClaim (Dictionary<string,string> _claims)
        {
            this.claims.Union(_claims);
            return this;
        }

        public TokenJWT Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub,this.subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            }.Union(this.claims.Select(item => new Claim(item.Key,item.Value)));

            var Token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: this.audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(this.expiryInMinutes),
                signingCredentials: new SigningCredentials(this.securityKey,SecurityAlgorithms.HmacSha256)
                );
            
            return new TokenJWT(Token);

 
         
        }

        private void EnsureArguments()
        {
            if (this.securityKey == null)
              throw new ArgumentNullException("Secutity Key");
            
            if (string.IsNullOrEmpty(this.subject))
              throw new ArgumentNullException("subject");
            
            if (string.IsNullOrEmpty(this.issuer))
              throw new ArgumentNullException("issuer");

            if (string.IsNullOrEmpty(this.audience))
              throw new ArgumentNullException("audience");
        }
    }
}