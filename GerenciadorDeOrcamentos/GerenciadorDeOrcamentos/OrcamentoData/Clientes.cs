using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoData
{
    public class Clientes
    {
        [Display(Name = "Id")]
        public int IdCliente { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome do Cliente deve ser preenchido.")]
        public string NomeCliente { get; set; }


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF deve ser preenchido e ter 11 dígitos.")]
        [StringLength(11)]
        [MinLength(11)]
        public string CPF { get; set; }


        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo RG deve ser preenchido e ter 10 dígitos.")]
        [StringLength(10)]
        [MinLength(10)]
        public string RG { get; set; }


        [Display(Name = "Telefone")]
        [StringLength(12)]
        public string Telefone { get; set; }


        [Display(Name = "Endereço")]
        public string Endereco { get; set; }


        [Display(Name = "Número")]
        public int Numero { get; set; }


        [Display(Name = "Bairro")]
        public string Bairro { get; set; }


        [Display(Name = "Cidade")]
        public string Cidade { get; set; }


        [Display(Name = "UF")]
        [StringLength(2)]
        [MinLength(2)]
        public string UF { get; set; }


        [Display(Name = "CEP")]
        [StringLength(9)]
        [MinLength(9)]
        public string CEP { get; set; }
    }
}
