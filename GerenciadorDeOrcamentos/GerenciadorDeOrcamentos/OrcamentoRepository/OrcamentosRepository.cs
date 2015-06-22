using MySql.Data.MySqlClient;
using OrcamentoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexao;

namespace OrcamentoRepository
{
    public class OrcamentosRepository
    {
        public static List<Orcamentos> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Orcamentos> Orcamento = new List<Orcamentos>();

            sql.Append("Select o.idorcamento, nomecliente, nomeproduto ");
            sql.Append("From orcamentos o ");
            sql.Append("inner join clientes c ");
            sql.Append("on o.idcliente=c.idcliente ");
            sql.Append("inner join orcamentosprodutos op ");
            sql.Append("on o.idorcamento=op.idorcamento ");
            sql.Append("inner join produtos p ");
            sql.Append("on op.idproduto=p.idproduto ");
            sql.Append("order by idorcamento asc");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                Orcamento.Add(
                    new Orcamentos
                    {
                        IdOrcamento = (int)dr["idorcamento"],
                        Cliente = new Clientes
                        {
                            NomeCliente = (string)dr["nomecliente"]
                        },
                        Produto = (List<Produtos>)dr["nomeproduto"]
                    }
                );
            }
            dr.Close();
            return Orcamento;
        }

        public static Orcamentos GetOne(int pIdOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select o.idorcamento, nomecliente, nomeproduto ");
            sql.Append("From orcamentos o ");
            sql.Append("inner join clientes c ");
            sql.Append("on o.idcliente=c.idcliente ");
            sql.Append("inner join orcamentosprodutos op ");
            sql.Append("on o.idorcamento=op.idorcamento ");
            sql.Append("inner join produtos p ");
            sql.Append("on op.idproduto=p.idproduto ");
            sql.Append("Where idorcamento=@idorcamento");

            cmd.Parameters.AddWithValue("@idorcamento", pIdOrcamento);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            Orcamentos Orcamento;

            Orcamento = new Orcamentos
            {
                IdOrcamento = (int)dr["idorcamento"],
                Cliente = new Clientes
                {
                    NomeCliente = (string)dr["nomecliente"]
                },
                Produto = (List<Produtos>)dr["nomeproduto"]
            };

            dr.Close();
            return Orcamento;
        }

        public void Create(Orcamentos pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Insert into orcamentos (idorcamento, idcliente, produtos)" );
            sql.Append("values(@idorcamento, @idcliente, @produtos)" );

            cmd.Parameters.AddWithValue("@idorcamento", pOrcamento.IdOrcamento);
            cmd.Parameters.AddWithValue("@idcliente", pOrcamento.Cliente.IdCliente);
            cmd.Parameters.AddWithValue("@produtos", pOrcamento.Produto);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Delete(int pIdOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Delete from orcamentos ");
            sql.Append("where idorcamento=@idorcamento");

            cmd.Parameters.AddWithValue("@idorcamento", pIdOrcamento);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Edit(Orcamentos pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update orcamentos ");
            sql.Append("set idcliente=@idcliente, produtos=@produtos ");
            sql.Append("where idorcamento=@idorcamento");


            cmd.Parameters.AddWithValue("@idorcamento", pOrcamento.IdOrcamento);
            cmd.Parameters.AddWithValue("@idcliente", pOrcamento.Cliente.IdCliente);
            cmd.Parameters.AddWithValue("@produtos", pOrcamento.Produto);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }
    }
}
