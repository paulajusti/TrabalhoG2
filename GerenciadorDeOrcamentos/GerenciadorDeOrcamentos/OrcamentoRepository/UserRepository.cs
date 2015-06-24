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
    public class UserRepository
    {
        public static List<User> Get()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<User> contas = new List<User>();

            sql.Append("Select *");
            sql.Append("From usuarios");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                contas.Add(
                    new User
                    {
                        idusuario = (int)dr["idusuario"],
                        emailusuario = (string)dr["emailusuario"],
                        senhausuario = (string)dr["senhausuario"],
                    }
                );
            }
            dr.Close();
            return contas;
        }

        public static User GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select *");
            sql.Append("From usuarios ");
            sql.Append("Where usuarios.id=@id");

            cmd.Parameters.AddWithValue("@id", pId);

            User conta;
            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            conta = new User
            {
                idusuario = (int)dr["idusuario"],
                emailusuario = (string)dr["emailusuario"],
                senhausuario = (string)dr["senhausuario"],

            };

            dr.Close();
            return conta;
        }


        public bool doLogin(string emailusuario, string senhausuario)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            var a = (sql.Append("Select * from usuarios Where emailusuario=@emailusuario && senhausuario=@senhausuario"));

            cmd.Parameters.AddWithValue("@emailusuario", emailusuario);
            cmd.Parameters.AddWithValue("@senhausuario", senhausuario);

            cmd.CommandText = sql.ToString();
            MySqlDataReader dr = BaseDados.Get(cmd);

            if (dr.HasRows == false)
                return false;
            else
                return true;
            dr.Read();
            dr.Close();
            return true;
        }

        public void Create(User pConta)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Insert into usuarios (idusuario, emailusuario, senhausuario)");
            sql.Append("values(@idusuario, @emailusuario, @senhausuario)");

            cmd.Parameters.AddWithValue("@idusuario", pConta.idusuario);
            cmd.Parameters.AddWithValue("@emailusuario", pConta.emailusuario);
            cmd.Parameters.AddWithValue("@senhausuario", pConta.senhausuario);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Delete from usuarios ");
            sql.Append("where idusuario=@id");

            cmd.Parameters.AddWithValue("@idusuario", pId);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        /*  public void Edit(User pConta)
          {
              StringBuilder sql = new StringBuilder();
              MySqlCommand cmd = new MySqlCommand();
              sql.Append("update usuarios ");
              sql.Append("set idusuario=@idusuario, emailusuario=@emailusuario, senhausuario=@senhausuario");
              sql.Append("where idusuario=@idusuario");

              cmd.Parameters.AddWithValue("@idusuario", pConta.idusuario);
              cmd.Parameters.AddWithValue("@emailusuario", pConta.emailusuario);
              cmd.Parameters.AddWithValue("@senhausuario", pConta.senhausuario);

              cmd.CommandText = sql.ToString();

              LoginConn.CommandPersist(cmd);
          } */
    }
}