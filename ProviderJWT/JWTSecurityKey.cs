using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections;

namespace WebAPIOrcamento.ProviderJWT
{
    public class JWTSecurity_Key
    {
       public static SymmetricSecurityKey Create(string secret)  
       {
           return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
       }

    }
}