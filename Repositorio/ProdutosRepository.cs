using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class ProdutosRepository : IGenericRepository<TbProdutos>
    {
        private readonly DbOrcamentoContext _Contexto;
        public ProdutosRepository(DbOrcamentoContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(TbProdutos OBJ)
        {
          _Contexto.TbProdutos.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public TbProdutos Find(long id)
        {
           return _Contexto.TbProdutos.FirstOrDefault(u => u.ICodProduto == id);
        }

        public IEnumerable<TbProdutos> GetAll()
        {
          return _Contexto.TbProdutos.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.TbProdutos.First(u => u.ICodProduto == id);
            _Contexto.TbProdutos.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(TbProdutos produto)
        {
           _Contexto.TbProdutos.Update(produto);
        }
    }
}

