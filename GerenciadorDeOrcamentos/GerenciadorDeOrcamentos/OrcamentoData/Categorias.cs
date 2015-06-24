using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoData
{
    public class Categorias
    {
        [Display(Name = "Id")]
        public int IdCategoria { get; set; }


        [Display(Name = "Nome da Categoria")]
        [Required(ErrorMessage = "O campo Nome da Categoria deve ser preenchido.")]
        public string NomeCategoria { get; set; }


        [Display(Name = "Descrição da Categoria")]
        [Required(ErrorMessage = "O campo Descrição da Categoria deve ser preenchido.")]
        public string DescricaoCategoria { get; set; }
    }
}
