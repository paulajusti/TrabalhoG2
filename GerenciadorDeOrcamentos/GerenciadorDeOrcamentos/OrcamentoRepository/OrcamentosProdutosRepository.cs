using Conexao;
using MySql.Data.MySqlClient;
using OrcamentoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentoRepository
{
    public class OrcamentosProdutosRepository
    {
        public static List<OrcamentosProdutos> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<OrcamentosProdutos> OrcamentoProduto = new List<OrcamentosProdutos>();

            sql.Append("Select op.*, o.idorcamento, p.idproduto, p.nomeproduto, p.valor ");
            sql.Append("From orcamentosprodutos op ");
            sql.Append("inner join orcamentos o ");
            sql.Append("on o.idorcamento=op.idorcamento ");
            sql.Append("inner join produtos p ");
            sql.Append("on p.idproduto=op.idproduto ");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                OrcamentoProduto.Add(
                    new OrcamentosProdutos
                    {
                        Orcamento = new Orcamentos
                        {
                            IdOrcamento = (int)dr["idorcamento"]
                        },
                        Produto = new Produtos
                        {
                            NomeProduto = (string)dr["nomeproduto"],
                            Valor = (decimal)dr["valor"],
                            IdProduto = (int)dr["idproduto"]
                        },
                        Quantidade = (decimal)dr["quantidade"],
                        TotalItem = (decimal)dr["totalitem"]
                    }
                );
            }
            dr.Close();
            return OrcamentoProduto;
        }

        public static OrcamentosProdutos GetOne(int pIdOrcamento, int pIdProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select op.*, o.idorcamento, p.idproduto ");
            sql.Append("From orcamentosprodutos op ");
            sql.Append("inner join orcamentos o ");
            sql.Append("on o.idorcamento=op.idorcamento ");
            sql.Append("inner join produtos p ");
            sql.Append("on p.idproduto=op.idproduto ");
            sql.Append("Where op.idorcamento=@idorcamento and op.idproduto=@idproduto");

            cmd.Parameters.AddWithValue("@idorcamento", pIdOrcamento);
            cmd.Parameters.AddWithValue("@idproduto", pIdProduto);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            OrcamentosProdutos OrcamentoProduto;

            OrcamentoProduto = new OrcamentosProdutos
            {
                Orcamento = new Orcamentos
                {
                    IdOrcamento = (int)dr["idorcamento"]
                },
                Produto = new Produtos
                {
                    IdProduto = (int)dr["idproduto"]
                },
                Quantidade = (decimal)dr["quantidade"],
                TotalItem = (decimal)dr["totalitem"]
            };

            dr.Close();
            return OrcamentoProduto;
        }

        public static int Create(OrcamentosProdutos pOrcProd)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            Orcamentos Orcamentos = new Orcamentos();
            Orcamentos = OrcamentosRepository.MaxId();
            int IdOrcamento = Orcamentos.IdOrcamento;

            Produtos Produto = new Produtos();
            Produto = ProdutosRepository.GetOne(pOrcProd.Produto.IdProduto);
            pOrcProd.TotalItem = Produto.Valor * pOrcProd.Quantidade;

            sql.Append("Insert into orcamentosprodutos ");
            sql.Append("values(@idorcamento, @idproduto, @quantidade, @totalitem)");

            cmd.Parameters.AddWithValue("@idorcamento", IdOrcamento);
            cmd.Parameters.AddWithValue("@idproduto", pOrcProd.Produto.IdProduto);
            cmd.Parameters.AddWithValue("@quantidade", pOrcProd.Quantidade);
            cmd.Parameters.AddWithValue("@totalitem", pOrcProd.TotalItem);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);

            return IdOrcamento;
        }

        public void Edit(OrcamentosProdutos pOrcProd)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            Produtos Produto = new Produtos();
            Produto = ProdutosRepository.GetOne(pOrcProd.Produto.IdProduto);
            pOrcProd.TotalItem = Produto.Valor * pOrcProd.Quantidade;

            sql.Append("Update orcamentosprodutos ");
            sql.Append("set quantidade=@quantidade, totalitem=@totalitem ");
            sql.Append("where idorcamento=@idorcamento and idproduto=@idproduto");

            cmd.Parameters.AddWithValue("@quantidade", pOrcProd.Quantidade);
            cmd.Parameters.AddWithValue("@totalitem", pOrcProd.TotalItem);
            cmd.Parameters.AddWithValue("@idorcamento", pOrcProd.Orcamento.IdOrcamento);
            cmd.Parameters.AddWithValue("@idproduto", pOrcProd.Produto.IdProduto);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }
        public void Delete(int pIdOrcamento, int pIdProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Delete from orcamentosprodutos ");
            sql.Append("where idorcamento=@idorcamento and idproduto=@idproduto");

            cmd.Parameters.AddWithValue("@idorcamento", pIdOrcamento);
            cmd.Parameters.AddWithValue("@idporduto", pIdProduto);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }
    }
}
