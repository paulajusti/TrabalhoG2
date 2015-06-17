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
    public class UnidadesRepository
    {
        public static List<Unidades> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Unidades> Unidade = new List<Unidades>();

            sql.Append("Select * ");
            sql.Append("From unidades ");
            sql.Append("order by idunidade asc");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd.CommandText);

            while (dr.Read())
            {
                Unidade.Add(
                    new Unidades
                    {
                        IdUnidade = (int)dr["idunidade"],
                        NomeUnidade = (string)dr["nomeunidade"],
                        Sigla = (string)dr["sigla"]
                    }
                );
            }
            dr.Close();
            return Unidade;
        }

        public static Unidades GetOne(int pIdUnidade)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select * ");
            sql.Append("From unidades ");
            sql.Append("Where idunidade=@idunidade");

            cmd.Parameters.AddWithValue("@idunidade", pIdUnidade);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd.CommandText);

            dr.Read();

            Unidades Unidade;

            Unidade = new Unidades
            {
                IdUnidade = (int)dr["idorcamento"],
                NomeUnidade = (string)dr["nomeunidade"],
                Sigla = (string)dr["sigla"]
            };

            dr.Close();
            return Unidade;
        }

        public void Create(Unidades pUnidade)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Insert into unidades (idunidade, nomeunidade, sigla)");
            sql.Append("values(@idunidade, @nomeunidade, @sigla)");

            cmd.Parameters.AddWithValue("@idunidade", pUnidade.IdUnidade);
            cmd.Parameters.AddWithValue("@nomeunidade", pUnidade.NomeUnidade);
            cmd.Parameters.AddWithValue("@sigla", pUnidade.Sigla);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Delete(int pIdUnidade)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Delete from unidades ");
            sql.Append("where idunidade=@idunidade");

            cmd.Parameters.AddWithValue("@idunidade", pIdUnidade);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Edit(Unidades pUnidade)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update unidades ");
            sql.Append("set nomeunidade=@nomeunidade, sigla=@siglas ");
            sql.Append("where idunidade=@idunidade");


            cmd.Parameters.AddWithValue("@idunidade", pUnidade.IdUnidade);
            cmd.Parameters.AddWithValue("@nomeunidade", pUnidade.NomeUnidade);
            cmd.Parameters.AddWithValue("@sigla", pUnidade.Sigla);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }
    }
}
