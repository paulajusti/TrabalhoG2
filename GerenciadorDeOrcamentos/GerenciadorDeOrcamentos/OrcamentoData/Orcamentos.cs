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
        public int IdOrcamento { get; set; }
        public Clientes Cliente { get; set; }
    }
}
