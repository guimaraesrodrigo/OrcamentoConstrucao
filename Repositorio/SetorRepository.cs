using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class SetorRepository : IGenericRepository<TbSetor>
    {
        private readonly DbOrcamentoContext _Contexto;
        public SetorRepository(DbOrcamentoContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(TbSetor OBJ)
        {
          _Contexto.TbSetor.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public TbSetor Find(long id)
        {
           return _Contexto.TbSetor.FirstOrDefault(u => u.ICodSetor == id);
        }

        public IEnumerable<TbSetor> GetAll()
        {
          return _Contexto.TbSetor.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.TbSetor.First(u => u.ICodSetor == id);
            _Contexto.TbSetor.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(TbSetor setor)
        {
           _Contexto.TbSetor.Update(setor);
        }
    }
}

