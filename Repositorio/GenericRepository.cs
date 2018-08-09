using System.Collections.Generic;

namespace WebAPIOrcamento.Repositorio
{
    public interface IGenericRepository<T>
    {
    
        void Add(T OBJ);
        
         IEnumerable<T> GetAll();

         T Find(long id);

         void Remover(long id);

         void Update(T produto);
        


    }
}