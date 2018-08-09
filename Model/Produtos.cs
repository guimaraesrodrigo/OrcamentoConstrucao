using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIOrcamento.Model
{
    
    [Table("Produtos", Schema = "public")]
    public class Produtos
    {
        [Key]
        public int codigo { get; set; }
        public string descricao { get; set; }   
        public double preco {get;set;}               
        public System.DateTime data_cadastro { get; set; }
      
    }
}