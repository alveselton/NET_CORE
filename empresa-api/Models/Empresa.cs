using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Models
{
    public class Empresa
    {
        [Key]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string RazaoSocial { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}