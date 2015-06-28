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
    public class ProdutosRepository
    {
        public static List<Produtos> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Produtos> Produto = new List<Produtos>();

            sql.Append("Select p.*, nomecategoria, sigla ");
            sql.Append("From produtos p ");
            sql.Append("inner join categorias c ");
            sql.Append("on p.idcategoria=c.idcategoria ");
            sql.Append("inner join unidades u ");
            sql.Append("on p.idunidade=u.idunidade ");
            sql.Append("order by idproduto asc");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                Produto.Add(
                    new Produtos
                    {
                        IdProduto = (int)dr["idproduto"],
                        NomeProduto = (string)dr["nomeproduto"],
                        Valor = (decimal)dr["valor"],
                        DescricaoProduto = (string)dr["descricaoproduto"],
                        Categoria = new Categorias
                        {
                            NomeCategoria = (string)dr["nomecategoria"],
                        },
                        Unidade = new Unidades
                        {
                            Sigla = (string)dr["sigla"]
                        }
                    }
                );
            }
            dr.Close();
            return Produto;
        }

        public static Produtos GetOne(int pIdProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select p.*, c.nomecategoria, u.sigla ");
            sql.Append("From produtos p ");
            sql.Append("inner join categorias c ");
            sql.Append("on (p.idcategoria=c.idcategoria) ");
            sql.Append("inner join unidades u ");
            sql.Append("on (p.idunidade=u.idunidade) ");
            sql.Append("Where p.idproduto=@idproduto");

            cmd.Parameters.AddWithValue("@idproduto", pIdProduto);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            Produtos Produto;

            Produto = new Produtos
            {
                IdProduto = (int)dr["idproduto"],
                NomeProduto = (string)dr["nomeproduto"],
                Valor = (decimal)dr["valor"],
                DescricaoProduto = (string)dr["descricaoproduto"],
                Categoria = new Categorias
                {
                    NomeCategoria = (string)dr["nomecategoria"],
                },
                Unidade = new Unidades
                {
                    Sigla = (string)dr["sigla"]
                }
            };

            dr.Close();
            return Produto;
        }

        public void Create(Produtos pProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Insert into produtos (idproduto, nomeproduto, valor, descricaoproduto, idcategoria, idunidade) ");
            sql.Append("values(@idproduto, @nomeproduto, @valor, @descricaoproduto, @idcategoria, @idunidade) ");

            cmd.Parameters.AddWithValue("@idproduto", pProduto.IdProduto);
            cmd.Parameters.AddWithValue("@nomeproduto", pProduto.NomeProduto);
            cmd.Parameters.AddWithValue("@valor", pProduto.Valor);
            cmd.Parameters.AddWithValue("@descricaoproduto", pProduto.DescricaoProduto);
            cmd.Parameters.AddWithValue("@idcategoria", pProduto.Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@idunidade", pProduto.Unidade.IdUnidade);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Delete(int pIdProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Delete from produtos ");
            sql.Append("where idproduto=@idproduto");

            cmd.Parameters.AddWithValue("@idproduto", pIdProduto);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Edit(Produtos pProduto)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update produtos ");
            sql.Append("set nomeproduto=@nomeproduto, valor=@valor, descricaoproduto=@descricaoproduto, idcategoria=@idcategoria, idunidade=@idunidade ");
            sql.Append("where idproduto=@idproduto");


            cmd.Parameters.AddWithValue("@idproduto", pProduto.IdProduto);
            cmd.Parameters.AddWithValue("@nomeproduto", pProduto.NomeProduto);
            cmd.Parameters.AddWithValue("@valor", pProduto.Valor);
            cmd.Parameters.AddWithValue("@descricaoproduto", pProduto.DescricaoProduto);
            cmd.Parameters.AddWithValue("@idcategoria", pProduto.Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@idunidade", pProduto.Unidade.IdUnidade);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }
    }
}
