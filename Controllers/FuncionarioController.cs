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
    
    public class FuncionarioController: ControllerBase
    {
      private readonly IGenericRepository<TbFuncionarios> _FuncionarioRepository;

      public FuncionarioController(IGenericRepository<TbFuncionarios> rep)
      {
            _FuncionarioRepository = rep;            
      }
      
      [HttpGet]    
      public IEnumerable<TbFuncionarios> GetAll()
      {           
           return _FuncionarioRepository.GetAll();            
      }

       [HttpGet("{id}",Name="GetFuncionario")]    
        public IActionResult GetById(long id)
        {
            try
            {
                var Funcionario = _FuncionarioRepository.Find(id);
                if (Funcionario ==null)
                return NotFound();

                return new OkObjectResult(Funcionario);   
            }
            catch (System.Exception e)
            {
               return Ok(e);
               
                throw;
            }                 
        }

        [HttpPost]
        public IActionResult Create([FromBody] TbFuncionarios funcionario)
        {
            _FuncionarioRepository.Add(funcionario);
            
            return CreatedAtRoute("GetFuncionario", new{id=funcionario.ICodFuncionario },funcionario );
        }
        
    }
}