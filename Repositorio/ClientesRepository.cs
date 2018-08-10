using System.Collections.Generic;
using WebAPIOrcamento.Model;
using System.Linq;

namespace WebAPIOrcamento.Repositorio
{
    public class ClientesRepository : IGenericRepository<TbClientes>
    {
        private readonly DbOrcamentoContext _Contexto;
        public ClientesRepository(DbOrcamentoContext ctx)
        {
          _Contexto = ctx;   
        }
        public void Add(TbClientes OBJ)
        {
          _Contexto.TbClientes.Add(OBJ);
          _Contexto.SaveChanges();
        }

        public TbClientes Find(long id)
        {
           return _Contexto.TbClientes.FirstOrDefault(u => u.ICodClientes == id);
        }

        public IEnumerable<TbClientes> GetAll()
        {
          return _Contexto.TbClientes.ToList();          
        }

        public void Remover(long id)
        {
            var entity = _Contexto.TbClientes.First(u => u.ICodClientes == id);
            _Contexto.TbClientes.Remove(entity);
            _Contexto.SaveChanges();
        }

        public void Update(TbClientes cliente)
        {
           _Contexto.TbClientes.Update(cliente);
        }
    }
}

