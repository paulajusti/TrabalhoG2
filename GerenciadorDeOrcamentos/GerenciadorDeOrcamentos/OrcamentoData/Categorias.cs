using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrcamentoData
{
    public class Categorias
    {

        public int IdCategoria { get; set; }



        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O campo Nome da Categoria deve ser preenchido.")]
        public string NomeCategoria { get; set; }



        [Display(Name = "Descrição:")]
        [Required(ErrorMessage = "O campo Descrição da Categoria deve ser preenchido.")]
        public string DescricaoCategoria { get; set; }

    }
}
