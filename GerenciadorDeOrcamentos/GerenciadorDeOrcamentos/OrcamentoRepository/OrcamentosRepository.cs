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

            sql.Append("Select o.idorcamento, c.* ");
            sql.Append("From orcamentos o ");
            sql.Append("inner join clientes c ");
            sql.Append("on o.idcliente=c.idcliente ");
            sql.Append("order by idorcamento asc");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                if (dr != null)
                {
                    Orcamento.Add(
                        new Orcamentos
                        {
                            IdOrcamento = (int)dr["idorcamento"],
                            Cliente = new Clientes
                            {
                                IdCliente = (int)dr["idcliente"],
                                NomeCliente = (string)dr["nomecliente"],
                                CPF = (string)dr["cpf"],
                                RG = (string)dr["rg"],
                                Telefone = (string)dr["telefone"],
                                Endereco = (string)dr["endereco"],
                                Numero = (int)dr["numero"],
                                Bairro = (string)dr["bairro"],
                                Cidade = (string)dr["cidade"],
                                UF = (string)dr["uf"],
                                CEP = (string)dr["cep"]
                            }
                        }
                    );
                }
            }
            dr.Close();
            return Orcamento;
        }

        public static Orcamentos GetOne(int pIdOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select o.idorcamento, c.* ");
            sql.Append("From orcamentos o ");
            sql.Append("inner join clientes c ");
            sql.Append("on o.idcliente=c.idcliente ");
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
                    IdCliente = (int)dr["idcliente"],
                    NomeCliente = (string)dr["nomecliente"],
                    CPF = (string)dr["cpf"],
                    RG = (string)dr["rg"],
                    Telefone = (string)dr["telefone"],
                    Endereco = (string)dr["endereco"],
                    Numero = (int)dr["numero"],
                    Bairro = (string)dr["bairro"],
                    Cidade = (string)dr["cidade"],
                    UF = (string)dr["uf"],
                    CEP = (string)dr["cep"]
                },
            };

            dr.Close();
            return Orcamento;
        }

        public static int Create()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Insert into orcamentos (idorcamento, idcliente) ");
            sql.Append("values(@idorcamento, 1)");

            Orcamentos Orcamento = OrcamentosRepository.MaxId();

            int id = Orcamento.IdOrcamento + 1;

            cmd.Parameters.AddWithValue("@idorcamento", id);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);

            return id;
        }

        //public void Create(Orcamentos pOrcamento)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    MySqlCommand cmd = new MySqlCommand();
        //    sql.Append("Insert into orcamentos (idorcamento, idcliente)" );
        //    sql.Append("values(@idorcamento, @idcliente)");

        //    cmd.Parameters.AddWithValue("@idorcamento", pOrcamento.IdOrcamento);
        //    cmd.Parameters.AddWithValue("@idcliente", pOrcamento.Cliente.IdCliente);

        //    cmd.CommandText = sql.ToString();

        //    BaseDados.ComandPersist(cmd);
        //}

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
            sql.Append("set idcliente=@idcliente ");
            sql.Append("where idorcamento=@idorcamento");

            cmd.Parameters.AddWithValue("@idorcamento", pOrcamento.IdOrcamento);
            cmd.Parameters.AddWithValue("@idcliente", pOrcamento.Cliente.IdCliente);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public static Orcamentos MaxId()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select idorcamento ");
            sql.Append("From orcamentos ");
            sql.Append("where idorcamento=( ");
            sql.Append("select max(idorcamento) ");
            sql.Append("from orcamentos) ");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            if (dr.HasRows)
            {
                //encontrou resultados
                Orcamentos Orcamento;

                Orcamento = new Orcamentos
                {
                    IdOrcamento = (int)dr["idorcamento"]
                };

                dr.Close();
                return Orcamento;
            }
            else
            {
                Orcamentos Orcamento;

                Orcamento = new Orcamentos
                {
                    IdOrcamento = 0
                };

                dr.Close();
                return Orcamento;
            }
        }

        public static List<Orcamentos> PesquisarOrcamentos(string Nome)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Orcamentos> Orcamento = new List<Orcamentos>();

            sql.Append("Select o.idorcamento, c.* ");
            sql.Append("From orcamentos o ");
            sql.Append("inner join clientes c ");
            sql.Append("on o.idcliente=c.idcliente where c.nomecliente like '%"+Nome+"%'");
            sql.Append("order by c.nomecliente asc");


            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                if (dr != null)
                {
                    Orcamento.Add(
                        new Orcamentos
                        {
                            IdOrcamento = (int)dr["idorcamento"],
                            Cliente = new Clientes
                            {
                                IdCliente = (int)dr["idcliente"],
                                NomeCliente = (string)dr["nomecliente"],
                                CPF = (string)dr["cpf"],
                                RG = (string)dr["rg"],
                                Telefone = (string)dr["telefone"],
                                Endereco = (string)dr["endereco"],
                                Numero = (int)dr["numero"],
                                Bairro = (string)dr["bairro"],
                                Cidade = (string)dr["cidade"],
                                UF = (string)dr["uf"],
                                CEP = (string)dr["cep"]
                            }
                        }
                    );
                }
            }
            dr.Close();
            return Orcamento;
        }
    }
}
