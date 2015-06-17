using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoData
{
    public class Orcamentos
    {
        public int IdOrcamento { get; set; }
        public Clientes Cliente { get; set; }
        public List<Produtos> Produto { get; set; }
    }
}
