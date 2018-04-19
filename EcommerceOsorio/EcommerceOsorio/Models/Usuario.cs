using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Display(Name = "E-mail do usuário")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha do usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }
}