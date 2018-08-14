using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class FuncionarioRepository : IGenericRepository<TbFuncionarios>
    {
        private readonly DbOrcamentoContext _Contexto;
        public FuncionarioRepository(DbOrcamentoContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(TbFuncionarios OBJ)
        {
          _Contexto.TbFuncionarios.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public TbFuncionarios Find(long id)
        {
           return _Contexto.TbFuncionarios.FirstOrDefault(u => u.ICodFuncionario == id);
        }

        public IEnumerable<TbFuncionarios> GetAll()
        {
          return _Contexto.TbFuncionarios.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.TbFuncionarios.First(u => u.ICodFuncionario == id);
            _Contexto.TbFuncionarios.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(TbFuncionarios funcrionario)
        {
           _Contexto.TbFuncionarios.Update(funcrionario);
        }
    }
}

