using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class OrcamentoItemRepository : IGenericRepository<TbOrcamentoItem>
    {
        private readonly DbOrcamentoContext _Contexto;
        public OrcamentoItemRepository(DbOrcamentoContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(TbOrcamentoItem OBJ)
        {
          _Contexto.TbOrcamentoItem.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public TbOrcamentoItem Find(long id)
        {
           return _Contexto.TbOrcamentoItem.FirstOrDefault(u => u.ICodOrcamento == id);
        }

        public IEnumerable<TbOrcamentoItem> GetAll()
        {
          return _Contexto.TbOrcamentoItem.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.TbOrcamentoItem.First(u => u.ICodOrcamento == id);
            _Contexto.TbOrcamentoItem.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(TbOrcamentoItem Orcamento)
        {
           _Contexto.TbOrcamentoItem.Update(Orcamento);
        }
    }
}

