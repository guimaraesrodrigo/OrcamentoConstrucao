using Microsoft.AspNetCore.Mvc;
using WebAPIOrcamento.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPIOrcamento.Repositorio;
using Microsoft.AspNetCore.Authorization;
using System;

namespace WebAPIOrcamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    
    [Authorize( Policy = "OrcamentoAPI")]      
    public class ProdutosController: ControllerBase
    {
        private readonly IGenericRepository<TbProdutos> _produtoRepositorio;
        
        public ProdutosController(IGenericRepository<TbProdutos> rep)
        {
            _produtoRepositorio = rep;
            
        }
        [HttpGet]
        public IEnumerable<TbProdutos> GetAll()
        {           
           return _produtoRepositorio.GetAll();            
        }

        [HttpGet("{id}",Name="GetProdutos")]
        public IActionResult GetById(long id)
        {
            try
            {
                var Produtos = _produtoRepositorio.Find(id);
                if (Produtos ==null)
                return NotFound();

                return new OkObjectResult(Produtos);   
            }
            catch (System.Exception e)
            {
               return Ok(e);
               
                throw;
            }     
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] TbProdutos Prod)
        {
            _produtoRepositorio.Add(Prod);
            
            return CreatedAtRoute("GetProdutos", new{id=Prod.ICodProduto },Prod );
        }

        
    }
}