using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class OrcamentoRepository : IGenericRepository<TbOrcamento>
    {
        private readonly DbOrcamentoContext _Contexto;
        public OrcamentoRepository(DbOrcamentoContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(TbOrcamento OBJ)
        {
          _Contexto.TbOrcamento.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public TbOrcamento Find(long id)
        {
           return _Contexto.TbOrcamento.FirstOrDefault(u => u.ICodOrcamento == id);
        }

        public IEnumerable<TbOrcamento> GetAll()
        {
          return _Contexto.TbOrcamento.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.TbOrcamento.First(u => u.ICodOrcamento == id);
            _Contexto.TbOrcamento.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(TbOrcamento Orcamento)
        {
           _Contexto.TbOrcamento.Update(Orcamento);
        }
    }
}

