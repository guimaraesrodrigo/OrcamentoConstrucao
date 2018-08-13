using System.IdentityModel.Tokens.Jwt;
using System;

namespace WebAPIOrcamento.ProviderJWT
{
    public class TokenJWT
    {
        private JwtSecurityToken token;
        public DateTime validto => token.ValidTo;
        public string value  => new JwtSecurityTokenHandler().WriteToken(this.token);

        internal TokenJWT(JwtSecurityToken _token)
        {
            token = _token;
        }



    }
}