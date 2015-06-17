using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoData
{
    public class Produtos
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public string DescricaoProduto { get; set; }
        public Categorias Categoria { get; set; }
        public Unidades Unidade { get; set; }
    }
}
