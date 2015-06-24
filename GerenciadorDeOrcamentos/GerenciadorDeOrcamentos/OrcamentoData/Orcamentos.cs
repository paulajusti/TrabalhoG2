using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrcamentoData
{
    public class Orcamentos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrcamento { get; set; }
        public Clientes Cliente { get; set; }
        //public List<Produtos> Produto { get; set; }
        public decimal TotalOrcamento { get; set; }
    }
}
