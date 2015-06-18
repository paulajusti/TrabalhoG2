using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrcamentoData
{
    public class Clientes
    {
        public int IdCliente { get; set; }


        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O campo Nome do Cliente deve ser preenchido.")]
        public string NomeCliente { get; set; }


        [Display(Name = "CPF:")]
        [Required(ErrorMessage = "O campo CPF deve ser preenchido.")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo do cpf são 11 caracteres.")]
        [StringLength(11, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        [MaxLength(11, ErrorMessage = "O tamanho máximo do nome são 11 caracteres.")]
        public string CPF { get; set; }


        [Display(Name = "RG:")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo do nome são 11 caracteres.")]
        [StringLength(11, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        [MaxLength(11, ErrorMessage = "O tamanho máximo do nome são 11 caracteres.")]
        public string RG { get; set; }


        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }


        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Display(Name = "Número:")]
        public int Numero { get; set; }


        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }


        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }


        [Display(Name = "UF:")]
        public string UF { get; set; }

         [Display(Name = "CEP:")]
        public string CEP { get; set; }
    }
}
