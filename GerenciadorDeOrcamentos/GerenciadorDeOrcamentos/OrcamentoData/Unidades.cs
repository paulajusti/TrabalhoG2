using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoData
{
    public class Unidades
    {
        public int IdUnidade { get; set; }


        [Display(Name = "Nome da Unidade")]
        public string NomeUnidade { get; set; }


        [Display(Name = "Sigla")]
        [StringLength(2)]
        [MinLength(2)]
        public string Sigla { get; set; }
    }
}
