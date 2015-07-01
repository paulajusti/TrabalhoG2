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
    public class ClientesRepository
    {
        public static List<Clientes> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Clientes> Cliente = new List<Clientes>();

            sql.Append("Select * ");
            sql.Append("From clientes ");
            sql.Append("order by idcliente asc");
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                Cliente.Add(
                    new Clientes
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
                );
            }
            dr.Close();
            return Cliente;
        }

        public static Clientes GetOne(int pIdCliente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("Select * ");
            sql.Append("From clientes ");
            sql.Append("Where idcliente=@idcliente");

            cmd.Parameters.AddWithValue("@idcliente", pIdCliente);

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            dr.Read();

            Clientes Cliente;

            if (dr != null)
            {
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
                };
            }
            else
            {
                Cliente = new Clientes
                {
                    IdCliente = (int)dr["idcliente"],
                    NomeCliente = (string)dr["nomecliente"]
                };
            }

            dr.Close();
            return Cliente;
        }

        public void Create(Clientes pCliente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("Insert into clientes (nomecliente, cpf, rg, telefone, endereco, numero, bairro, cidade, uf, cep) ");
            sql.Append("values(@nomecliente, @cpf, @rg, @telefone, @endereco, @numero, @bairro, @cidade, @uf, @cep)");

            cmd.Parameters.AddWithValue("@nomecliente", pCliente.NomeCliente);
            cmd.Parameters.AddWithValue("@cpf", pCliente.CPF);
            cmd.Parameters.AddWithValue("@rg", pCliente.RG);
            cmd.Parameters.AddWithValue("@telefone", pCliente.Telefone);
            cmd.Parameters.AddWithValue("@endereco", pCliente.Endereco);
            cmd.Parameters.AddWithValue("@numero", pCliente.Numero);
            cmd.Parameters.AddWithValue("@bairro", pCliente.Bairro);
            cmd.Parameters.AddWithValue("@cidade", pCliente.Cidade);
            cmd.Parameters.AddWithValue("@uf", pCliente.UF);
            cmd.Parameters.AddWithValue("@cep", pCliente.CEP);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public void Delete(int pIdCliente)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                MySqlCommand cmd = new MySqlCommand();
                sql.Append("Delete from clientes ");
                sql.Append("where idcliente=@idcliente");

                cmd.Parameters.AddWithValue("@idcliente", pIdCliente);

                cmd.CommandText = sql.ToString();

                BaseDados.ComandPersist(cmd);
            }
            catch (Exception)
            {
            }
        }

        public void Edit(Clientes pCliente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update clientes ");
            sql.Append("set nomecliente=@nomecliente, cpf=@cpf, rg=@rg, telefone=@telefone, endereco=@endereco, numero=@numero, bairro=@bairro, cidade=@cidade, uf=@uf, cep=@cep ");
            sql.Append("where idcliente = @idcliente");

            cmd.Parameters.AddWithValue("@idcliente", pCliente.IdCliente);
            cmd.Parameters.AddWithValue("@nomecliente", pCliente.NomeCliente);
            cmd.Parameters.AddWithValue("@cpf", pCliente.CPF);
            cmd.Parameters.AddWithValue("@rg", pCliente.RG);
            cmd.Parameters.AddWithValue("@telefone", pCliente.Telefone);
            cmd.Parameters.AddWithValue("@endereco", pCliente.Endereco);
            cmd.Parameters.AddWithValue("@numero", pCliente.Numero);
            cmd.Parameters.AddWithValue("@bairro", pCliente.Bairro);
            cmd.Parameters.AddWithValue("@cidade", pCliente.Cidade);
            cmd.Parameters.AddWithValue("@uf", pCliente.UF);
            cmd.Parameters.AddWithValue("@cep", pCliente.CEP);

            cmd.CommandText = sql.ToString();

            BaseDados.ComandPersist(cmd);
        }

        public static List<Clientes> PesquisarClientes(string Nome)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Clientes> Cliente = new List<Clientes>();

            sql.Append("Select * ");
            sql.Append("From clientes where nomecliente like '%" + Nome + "%'");
            sql.Append("order by nomecliente asc");
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = BaseDados.Get(cmd);

            while (dr.Read())
            {
                Cliente.Add(
                    new Clientes
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
                );
            }
            dr.Close();
            return Cliente;
        }
    }
}