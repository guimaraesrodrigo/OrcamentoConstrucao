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
    
    public class ClientesController: ControllerBase
    {
      private readonly IGenericRepository<TbClientes> _ClientesRepository;

      public ClientesController(IGenericRepository<TbClientes> rep)
      {
            _ClientesRepository = rep;            
      }
      
      [HttpGet]    
      public IEnumerable<TbClientes> GetAll()
      {           
           return _ClientesRepository.GetAll();            
      }

       [HttpGet("{id}",Name="Getclientes")]    
        public IActionResult GetById(long id)
        {
            try
            {
                var Clientes = _ClientesRepository.Find(id);
                if (Clientes ==null)
                return NotFound();

                return new OkObjectResult(Clientes);   
            }
            catch (System.Exception e)
            {
               return Ok(e);
               
                throw;
            }                 
        }

        [HttpPost]
        public IActionResult Create([FromBody] TbClientes Cliente)
        {
            _ClientesRepository.Add(Cliente);
            
            return CreatedAtRoute("Getclientes", new{id=Cliente.ICodClientes },Cliente );
        }
        
    }
}