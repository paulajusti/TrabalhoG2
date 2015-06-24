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
    public class CategoriasRepository
    {
        public static List<Categorias> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Categorias> Categoria = new List<Categorias>();

            sql.Append("Select * ");
            sql.Append("From categorias ");
            sql.Append("order by idcategoria asc");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                Categoria.Add(
                    new Categorias
                    {
                        IdCategoria  = (int)dr["idcategoria"],
                        NomeCategoria = (string)dr["nomecategoria"],
                        DescricaoCategoria = (string)dr["descricaocategoria"]
                    }
                );
            }
            dr.Close();
            return Categoria;
        }

        public static Categorias GetOne(int pIdCategoria)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select * ");
            sql.Append("From categorias ");
            sql.Append("Where idcategoria=@idcategoria");

            cmd.Parameters.AddWithValue("@idcategoria", pIdCategoria);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            Categorias Categoria;

            Categoria = new Categorias
            {
                IdCategoria = (int)dr["idcategoria"],
                NomeCategoria = (string)dr["nomecategoria"],
                DescricaoCategoria = (string)dr["descricaocategoria"]
            };

            dr.Close();
            return Categoria;
        }

        public void Create(Categorias pCategoria)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Insert into categorias (idcategoria, nomecategoria, descricaocategoria)");
            sql.Append("values(@idcategoria, @nomecategoria, @descricaocategoria)");

            cmd.Parameters.AddWithValue("@idcategoria", pCategoria.IdCategoria);
            cmd.Parameters.AddWithValue("@nomecategoria", pCategoria.NomeCategoria);
            cmd.Parameters.AddWithValue("@descricaocategoria", pCategoria.DescricaoCategoria);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Delete(int pIdCategoria)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Delete from categorias ");
            sql.Append("where idcategoria=@idcategoria");

            cmd.Parameters.AddWithValue("@idcategoria", pIdCategoria);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Edit(Categorias pCategorias)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update categorias ");
            sql.Append("set nomecategoria=@nomecategoria, descricaocategoria=@descricaocategoria ");
            sql.Append("where idcategoria=@idcategoria");


            cmd.Parameters.AddWithValue("@idcategoria", pCategorias.IdCategoria);
            cmd.Parameters.AddWithValue("@nomecategoria", pCategorias.NomeCategoria);
            cmd.Parameters.AddWithValue("@descricaocategoria", pCategorias.DescricaoCategoria);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }


        public static List<Categorias> PesquisarCategorias(string Nome)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Categorias> Categoria = new List<Categorias>();

            sql.Append("Select * ");
            sql.Append("From categorias where nomecategoria like '%"+Nome+"%'");
            sql.Append("order by nomecategoria asc");
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                Categoria.Add(
                    new Categorias
                    {
                        IdCategoria = (int)dr["idcategoria"],
                        NomeCategoria = (string)dr["nomecategoria"],
                        DescricaoCategoria = (string)dr["descricaocategoria"]
                    }
                );
            }
            dr.Close();
            return Categoria;
        }


    }
}
