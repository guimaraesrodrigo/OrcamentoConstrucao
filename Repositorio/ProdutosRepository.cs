using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class ProdutosRepository : IGenericRepository<Produtos>
    {
        private readonly MyWebApiContext _Contexto;
        public ProdutosRepository(MyWebApiContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(Produtos OBJ)
        {
          _Contexto.produtos.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public Produtos Find(long id)
        {
           return _Contexto.produtos.FirstOrDefault(u => u.codigo == id);
        }

        public IEnumerable<Produtos> GetAll()
        {
          return _Contexto.produtos.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.produtos.First(u => u.codigo == id);
            _Contexto.produtos.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(Produtos produto)
        {
           _Contexto.produtos.Update(produto);
        }
    }
}

