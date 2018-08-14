using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIOrcamento.Model;
using WebAPIOrcamento.Repositorio;
using Microsoft.AspNetCore.Authorization;


namespace WebAPIOrcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
     
    [Authorize( Policy = "OrcamentoAPI")]       
    
    public class SetorController: ControllerBase
    {
      private readonly IGenericRepository<TbSetor> _SetorRepository;

      public SetorController(IGenericRepository<TbSetor> rep)
      {
            _SetorRepository = rep;            
      }
      
      [HttpGet]    
      public IEnumerable<TbSetor> GetAll()
      {           
           return _SetorRepository.GetAll();            
      }

       [HttpGet("{id}",Name="GetSetor")]    
        public IActionResult GetById(long id)
        {
            try
            {
                var Setor = _SetorRepository.Find(id);
                if (Setor ==null)
                return NotFound();

                return new OkObjectResult(Setor);   
            }
            catch (System.Exception e)
            {
               return Ok(e);
               
                throw;
            }                 
        }

        [HttpPost]
        public IActionResult Create([FromBody] TbSetor setor)
        {
            _SetorRepository.Add(setor);
            
            return CreatedAtRoute("GetSetor", new{id=setor.ICodSetor },setor );
        }
        
    }
}