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


        [Display(Name = "Nome do Cliente:")]
        [Required(ErrorMessage = "O campo Nome do Cliente deve ser preenchido.")]
        public string NomeCliente { get; set; }

        [MinLength(11, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(11, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
