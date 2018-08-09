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
            services.AddTransient<IGenericRepository<Produtos>, ProdutosRepository>();            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);                        
            services.AddEntityFrameworkNpgsql().AddDbContext<MyWebApiContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostGreeOnline")));
            
            //var connectionString = Configuration.GetConnectionString("PostGreeOnline");
            //services.AddEntityFrameworkNpgsql().AddDbContext<MyWebApiContext>(options => options.UseNpgsql(connectionString));
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v3", new Info{Title = "APIProdutos",Version="v3"});

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
            app.UseSwagger();
            app.UseSwaggerUI( c=> 
            {
                c.SwaggerEndpoint("/swagger/v3/swagger.json","APIProdutos v3");
            });
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
