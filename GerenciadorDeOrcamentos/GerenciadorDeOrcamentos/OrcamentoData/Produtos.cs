using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrcamentoData
{
    public class Produtos
    {
        public int IdProduto { get; set; }


        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O campo Nome do Produto deve ser preenchido.")]
        public string NomeProduto { get; set; }


        [Display(Name = "Valor:")]
        [Required(ErrorMessage = "O campo valor do Produto deve ser preenchido.")]
        public decimal Valor { get; set; }


        [Display(Name = "Descrição:")]
        public string DescricaoProduto { get; set; }


        [Display(Name = "Categoria:")]
        [Required(ErrorMessage = "O campo categoria do Produto deve ser preenchido.")]
        public Categorias Categoria { get; set; }


        [Display(Name = "Unidade:")]
        [Required(ErrorMessage = "O campo unidade do Produto deve ser preenchido.")]
        public Unidades Unidade { get; set; }
    }
}
