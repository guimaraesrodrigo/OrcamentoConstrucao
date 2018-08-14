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
    
    public class OrcamentoController: ControllerBase
    {
      private readonly IGenericRepository<TbOrcamento> _OrcamentoRepository;

      public OrcamentoController(IGenericRepository<TbOrcamento> rep)
      {
            _OrcamentoRepository = rep;            
      }
      
      [HttpGet]    
      public IEnumerable<TbOrcamento> GetAll()
      {           
           return _OrcamentoRepository.GetAll();            
      }

       [HttpGet("{id}",Name="GetOrcamento")]    
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
        public IActionResult Create([FromBody] TbOrcamento orcamento)
        {
            _OrcamentoRepository.Add(orcamento);
            
            return CreatedAtRoute("GetOrcamento", new{id=orcamento.ICodOrcamento },orcamento );
        }
        
    }
}