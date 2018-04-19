using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string Cliente { get; set; }

        [Display(Name = "Endereço do Cliente")]
        public string Endereco { get; set; }
        public DateTime Data { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }
    }
}