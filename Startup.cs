using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebAPIOrcamento.Model;
using WebAPIOrcamento.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens; 



namespace WebAPIOrcamento
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            
            //original
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })                    
                    .AddJwtBearer( option => 
                    {
                      option.TokenValidationParameters  = new TokenValidationParameters                      
                      {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Orcamento.Secutiry.Bearer",
                        ValidAudience = "Orcamento.Secutiry.Bearer",
                        IssuerSigningKey = ProviderJWT.JWTSecurity_Key.Create("asd@12316051986OrcamentoAPI"),
                        

                      };
                    option.IncludeErrorDetails = true;
                      option.Events = new JwtBearerEvents
                      {
                          OnAuthenticationFailed = Context => 
                          {
                              Console.WriteLine("Autenticação Falhou: " + Context.Exception.Message);
                              return Task.CompletedTask;
                          },
                          OnTokenValidated = Context  =>
                          {
                              Console.WriteLine("Authenticado: "+Context.SecurityToken);
                              return Task.CompletedTask;
                          }
                      };

                    });
            
            services.AddAuthorization(option => 
            {               
                option.AddPolicy("OrcamentoAPI",
                  policy => 
                  {         
                        //policy.RequireClaim("UsuarioAPI");                
                        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                        policy.RequireAuthenticatedUser();                                                                        
                    });                 
                
            });
            


            services.AddTransient<IGenericRepository<TbProdutos>, ProdutosRepository>();            
            services.AddTransient<IGenericRepository<TbClientes>, ClientesRepository>();                        
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);                        
            services.AddEntityFrameworkMySql().AddDbContext<DbOrcamentoContext>(opt => opt.UseMySql(Configuration.GetConnectionString("MySQLConnectionString")));           
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v3", new Info{Title = "API-Orçamento",Version="v3"});

            } );
        
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI( c=> 
            {
                c.SwaggerEndpoint("/swagger/v3/swagger.json","API-Orçamento");
            });
        }
    }
}
