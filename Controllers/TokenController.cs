using Microsoft.AspNetCore.Mvc;
using WebAPIOrcamento.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPIOrcamento.Repositorio;
using Microsoft.AspNetCore.Authorization;
using System;
using WebAPIOrcamento.ProviderJWT;
using System.Linq;

namespace WebAPIOrcamento.Controllers
{
    
    public class Token: Controller
    {
        [Route("api/CreateToken")]   
        [AllowAnonymous]
        [HttpPost]
        
        public IActionResult CreateToken([FromBody] Usuario user)
        {
            if (user.nome!= "OrcamentoWebAPI" || user.senha != "asd@123")
              return Unauthorized();

              var dic = new Dictionary<string,string>();
              dic.Add("UsuarioAPI","Administrator");
            
            var token = new TokenJWTBuilder()
               .AddSecutiryKey(ProviderJWT.JWTSecurity_Key.Create("asd@12316051986OrcamentoAPI"))
               .AddSubject("OrcamentoWEBAPI")
               .Addissuer("Orcamento.Secutiry.Bearer")
               .AddAudience("Orcamento.Secutiry.Bearer")
               .AddClaim(dic)
               .AddExpireInMinutes(5000)            
               .Builder();              

            return Ok(token.value);    
        }
        
    }
}