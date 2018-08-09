using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebAPIOrcamento.Model
{
    public class MyWebApiContext: DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base (options)
        {

        }
        public DbSet<Produtos> produtos {get;set;}
        
    }
}