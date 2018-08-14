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
    
    public class OrcamentoItemController: ControllerBase
    {
      private readonly IGenericRepository<TbOrcamentoItem> _OrcamentoRepository;

      public OrcamentoItemController(IGenericRepository<TbOrcamentoItem> rep)
      {
            _OrcamentoRepository = rep;            
      }
      
      [HttpGet]    
      public IEnumerable<TbOrcamentoItem> GetAll()
      {           
           return _OrcamentoRepository.GetAll();            
      }

       [HttpGet("{id}",Name="GetOrcamentoItem")]    
        public IActionResult GetById(long id)
        {
            try
            {
                var Orcamento = _OrcamentoRepository.Find(id);
                if (Orcamento ==null)
                return NotFound();

                return new OkObjectResult(Orcamento);   
            }
            catch (System.Exception e)
            {
               return Ok(e);
               
                throw;
            }                 
        }

        [HttpPost]
        public IActionResult Create([FromBody] TbOrcamentoItem orcamento)
        {
            _OrcamentoRepository.Add(orcamento);
            
            return CreatedAtRoute("GetOrcamentoItem", new{id=orcamento.ICodOrcamento },orcamento );
        }
        
    }
}