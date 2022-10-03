using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class ClienteRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        internal void Adicionar(Cliente cliente)
        {
            ConectarSql();

            string comando = "INSERT INTO Cliente (Nome,DataNascimento,RG,Idade,CPF,Altura,Peso,Celular,Telefone,EstadoCivil,Profissao,Email, Elemento, NomeConjuge,NomePai,NomeMae,DataNascimentoMae,DataNascimentoPai,Endereco,Bairro,Cidade,CEP,Estado,Numero,Complemento, DataCadastro)" +
                                   "VALUES(@Nome,@DataNascimento,@RG,@Idade,@CPF,@Altura,@Peso,@Celular,@Telefone,@EstadoCivil,@Profissao,@Email, @Elemento, @NomeConjuge,@NomePai,@NomeMae,@DataNascimentoMae,@DataNascimentoPai,@Endereco,@Bairro,@Cidade,@CEP,@Estado,@Numero,@Complemento, @DataCadastro)";

            SqlCommand cmd = new SqlCommand(comando, conn);

            if (cliente.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = cliente.Nome;

            if (cliente.DataNascimento == null)
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = cliente.DataNascimento;

            if (cliente.RG == null)
                cmd.Parameters.Add("@RG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RG", SqlDbType.VarChar).Value = cliente.RG;

            if (cliente.Idade == null)
                cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = cliente.Idade;

            if (cliente.CPF == null)
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = cliente.CPF;

            if (cliente.Altura == null)
                cmd.Parameters.Add("@Altura", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Altura", SqlDbType.VarChar).Value = cliente.Altura;

            if (cliente.Peso == 0)
                cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = cliente.Peso;

            if (cliente.Celular == null)
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = cliente.Celular;

            if (cliente.Telefone == null)
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = cliente.Telefone;

            if (cliente.EstadoCivil == null)
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar).Value = cliente.EstadoCivil;

            if (cliente.Profissao == null)
                cmd.Parameters.Add("@Profissao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Profissao", SqlDbType.VarChar).Value = cliente.Profissao;

            if (cliente.Email == null)
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = cliente.Email;

            if (cliente.Elemento == null)
                cmd.Parameters.Add("@Elemento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Elemento", SqlDbType.VarChar).Value = cliente.Elemento;

            if (cliente.NomeConjuge == null)
                cmd.Parameters.Add("@NomeConjuge", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeConjuge", SqlDbType.VarChar).Value = cliente.NomeConjuge;

            if (cliente.NomePai == null)
                cmd.Parameters.Add("@NomePai", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomePai", SqlDbType.VarChar).Value = cliente.NomePai;

            if (cliente.NomeMae == null)
                cmd.Parameters.Add("@NomeMae", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeMae", SqlDbType.VarChar).Value = cliente.NomeMae;

            if (cliente.DataNascimentoMae == null)
                cmd.Parameters.Add("@DataNascimentoMae", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimentoMae", SqlDbType.DateTime).Value = cliente.DataNascimentoMae;

            if (cliente.DataNascimentoPai == null)
                cmd.Parameters.Add("@DataNascimentoPai", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimentoPai", SqlDbType.DateTime).Value = cliente.DataNascimentoPai;

            if (cliente.Endereco == null)
                cmd.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = cliente.Endereco;

            if (cliente.Bairro == null)
                cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = cliente.Bairro;

            if (cliente.Cidade == null)
                cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = cliente.Cidade;

            if (cliente.CEP == null)
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = cliente.CEP;

            if (cliente.Estado == null)
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = cliente.Estado;

            if (cliente.Numero == null)
                cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = cliente.Numero;

            if (cliente.Complemento == null)
                cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = cliente.Complemento;

            cmd.Parameters.Add("@DataCadastro", SqlDbType.DateTime).Value = DateTime.Now;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> BuscarTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            ConectarSql();

            string comando = "SELECT * FROM Cliente";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();

                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.Nome = Convert.ToString(reader["Nome"]);
                cliente.DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : DateTime.MinValue;
                cliente.RG = Convert.ToString(reader["RG"]);
                cliente.Idade = !string.IsNullOrEmpty(reader["Idade"].ToString()) ? Convert.ToInt32(reader["Idade"]) : 0;
                cliente.CPF = Convert.ToString(reader["CPF"]);
                cliente.Altura = Convert.ToString(reader["Altura"]);
                cliente.Peso = Convert.ToInt32(reader["Peso"]);
                cliente.Celular = Convert.ToString(reader["Celular"]);
                cliente.Telefone = Convert.ToString(reader["Telefone"]);
                cliente.EstadoCivil = Convert.ToString(reader["EstadoCivil"]);
                cliente.Profissao = Convert.ToString(reader["Profissao"]);
                cliente.Email = Convert.ToString(reader["Email"]);
                cliente.NomeConjuge = Convert.ToString(reader["NomeConjuge"]);
                cliente.NomePai = Convert.ToString(reader["NomePai"]);
                cliente.NomeMae = Convert.ToString(reader["NomeMae"]);
                cliente.DataNascimentoMae = reader["DataNascimentoMae"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimentoMae"]) : DateTime.MinValue;
                cliente.DataNascimentoPai = reader["DataNascimentoPai"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimentoPai"]) : DateTime.MinValue;
                cliente.Endereco = Convert.ToString(reader["Endereco"]);
                cliente.Bairro = Convert.ToString(reader["Bairro"]);
                cliente.Cidade = Convert.ToString(reader["Cidade"]);
                cliente.CEP = Convert.ToString(reader["CEP"]);
                cliente.Estado = Convert.ToString(reader["Estado"]);
                cliente.Numero = !string.IsNullOrEmpty(reader["Numero"].ToString()) ? Convert.ToInt32(reader["Numero"]) : 0;
                cliente.Complemento = Convert.ToString(reader["Complemento"]);
                cliente.DataCadastro = reader["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(reader["DataCadastro"]) : DateTime.MinValue;

                listaClientes.Add(cliente);
            }

            return listaClientes;
        }

        public Cliente Buscar(int id)
        {
            ConectarSql();

            string comando = "SELECT * FROM Cliente WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();

            Cliente cliente = new Cliente();

            while (reader.Read())
            {
                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.Nome = Convert.ToString(reader["Nome"]);
                cliente.DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : DateTime.MinValue;
                cliente.RG = Convert.ToString(reader["RG"]);
                cliente.Idade = !string.IsNullOrEmpty(reader["Idade"].ToString()) ? Convert.ToInt32(reader["Idade"]) : 0;
                cliente.CPF = Convert.ToString(reader["CPF"]);
                cliente.Altura = Convert.ToString(reader["Altura"]);
                cliente.Peso = Convert.ToInt32(reader["Peso"]);
                cliente.Celular = Convert.ToString(reader["Celular"]);
                cliente.Telefone = Convert.ToString(reader["Telefone"]);
                cliente.EstadoCivil = Convert.ToString(reader["EstadoCivil"]);
                cliente.Profissao = Convert.ToString(reader["Profissao"]);
                cliente.Email = Convert.ToString(reader["Email"]);
                cliente.Elemento = Convert.ToString(reader["Elemento"]);
                cliente.NomeConjuge = Convert.ToString(reader["NomeConjuge"]);
                cliente.NomePai = Convert.ToString(reader["NomePai"]);
                cliente.NomeMae = Convert.ToString(reader["NomeMae"]);
                cliente.DataNascimentoMae = reader["DataNascimentoMae"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimentoMae"]) : DateTime.MinValue;
                cliente.DataNascimentoPai = reader["DataNascimentoPai"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimentoPai"]) : DateTime.MinValue;
                cliente.Endereco = Convert.ToString(reader["Endereco"]);
                cliente.Bairro = Convert.ToString(reader["Bairro"]);
                cliente.Cidade = Convert.ToString(reader["Cidade"]);
                cliente.CEP = Convert.ToString(reader["CEP"]);
                cliente.Estado = Convert.ToString(reader["Estado"]);
                cliente.Numero = !string.IsNullOrEmpty(reader["Numero"].ToString()) ? Convert.ToInt32(reader["Numero"]) : 0;
                cliente.Complemento = Convert.ToString(reader["Complemento"]);
                cliente.DataCadastro = reader["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(reader["DataCadastro"]) : DateTime.MinValue;
            };

            return cliente;
        }

        public List<Cliente> BuscarPorNome(string nome)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            ConectarSql();

            string comando = @"SELECT * FROM Cliente WHERE Nome LIKE '%" + nome + "%'";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();

                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.Nome = Convert.ToString(reader["Nome"]);
                cliente.DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : DateTime.MinValue;
                cliente.RG = Convert.ToString(reader["RG"]);
                cliente.Idade = !string.IsNullOrEmpty(reader["Idade"].ToString()) ? Convert.ToInt32(reader["Idade"]) : 0;
                cliente.CPF = Convert.ToString(reader["CPF"]);
                cliente.Altura = Convert.ToString(reader["Altura"]);
                cliente.Peso = !string.IsNullOrEmpty(reader["Peso"].ToString()) ? Convert.ToInt32(reader["Peso"]) : 0; ;
                cliente.Celular = Convert.ToString(reader["Celular"]);
                cliente.Telefone = Convert.ToString(reader["Telefone"]);
                cliente.EstadoCivil = Convert.ToString(reader["EstadoCivil"]);
                cliente.Profissao = Convert.ToString(reader["Profissao"]);
                cliente.Email = Convert.ToString(reader["Email"]);
                cliente.Elemento = Convert.ToString(reader["Elemento"]);
                cliente.NomeConjuge = Convert.ToString(reader["NomeConjuge"]);
                cliente.NomePai = Convert.ToString(reader["NomePai"]);
                cliente.NomeMae = Convert.ToString(reader["NomeMae"]);
                cliente.DataNascimentoMae = reader["DataNascimentoMae"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimentoMae"]) : DateTime.MinValue;
                cliente.DataNascimentoPai = reader["DataNascimentoPai"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimentoPai"]) : DateTime.MinValue; 
                cliente.Endereco = Convert.ToString(reader["Endereco"]);
                cliente.Bairro = Convert.ToString(reader["Bairro"]);
                cliente.Cidade = Convert.ToString(reader["Cidade"]);
                cliente.CEP = Convert.ToString(reader["CEP"]);
                cliente.Estado = Convert.ToString(reader["Estado"]);
                cliente.Numero = !string.IsNullOrEmpty(reader["Numero"].ToString()) ? Convert.ToInt32(reader["Numero"]) : 0;
                cliente.Complemento = Convert.ToString(reader["Complemento"]);
                cliente.DataCadastro = reader["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(reader["DataCadastro"]) : DateTime.MinValue;

                listaClientes.Add(cliente);
            };

            return listaClientes;
        }

        internal void Alterar(Cliente cliente)
        {
            ConectarSql();

            string comando = "UPDATE Cliente SET  Nome = @Nome, DataNascimento = @DataNascimento, RG = @RG, Idade = @Idade, CPF = @CPF, Altura = @Altura, Peso = @Peso, Celular = @Celular, Telefone = @Telefone, EstadoCivil = @EstadoCivil, Profissao = @Profissao, Email = @Email, Elemento = @Elemento, NomeConjuge = @NomeConjuge, NomePai = @NomePai, NomeMae = @NomeMae, DataNascimentoMae = @DataNascimentoMae, DataNascimentoPai = @DataNascimentoPai, Endereco = @Endereco, Bairro = @Bairro, Cidade = @Cidade, CEP = @CEP, Estado = @Estado, Numero = @Numero, Complemento = @Complemento " +
                                "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = cliente.Id;

            if (cliente.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = cliente.Nome;

            if (cliente.DataNascimento.Equals(DateTime.MinValue) || cliente.DataNascimento == null)
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = cliente.DataNascimento;

            if (cliente.RG == null)
                cmd.Parameters.Add("@RG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RG", SqlDbType.VarChar).Value = cliente.RG;

            if (cliente.Idade == null)
                cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Idade", SqlDbType.Int).Value = cliente.Idade;

            if (cliente.CPF == null)
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = cliente.CPF;

            if (cliente.Altura == null)
                cmd.Parameters.Add("@Altura", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Altura", SqlDbType.VarChar).Value = cliente.Altura;

            if (cliente.Peso == 0)
                cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Peso", SqlDbType.Decimal).Value = cliente.Peso;

            if (cliente.Celular == null)
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = cliente.Celular;

            if (cliente.Telefone == null)
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = cliente.Telefone;

            if (cliente.EstadoCivil == null)
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar).Value = cliente.EstadoCivil;

            if (cliente.Profissao == null)
                cmd.Parameters.Add("@Profissao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Profissao", SqlDbType.VarChar).Value = cliente.Profissao;

            if (cliente.Email == null)
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = cliente.Email;

            if (cliente.Elemento == null)
                cmd.Parameters.Add("@Elemento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Elemento", SqlDbType.VarChar).Value = cliente.Elemento;

            if (cliente.NomeConjuge == null)
                cmd.Parameters.Add("@NomeConjuge", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeConjuge", SqlDbType.VarChar).Value = cliente.NomeConjuge;

            if (cliente.NomePai == null)
                cmd.Parameters.Add("@NomePai", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomePai", SqlDbType.VarChar).Value = cliente.NomePai;

            if (cliente.NomeMae == null)
                cmd.Parameters.Add("@NomeMae", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeMae", SqlDbType.VarChar).Value = cliente.NomeMae;

            if (cliente.DataNascimentoMae.Equals(DateTime.MinValue) || cliente.DataNascimentoMae == null)
                cmd.Parameters.Add("@DataNascimentoMae", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimentoMae", SqlDbType.DateTime).Value = cliente.DataNascimentoMae;

            if (cliente.DataNascimentoPai.Equals(DateTime.MinValue) || cliente.DataNascimentoPai == null)
                cmd.Parameters.Add("@DataNascimentoPai", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimentoPai", SqlDbType.DateTime).Value = cliente.DataNascimentoPai;

            if (cliente.Endereco == null)
                cmd.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = cliente.Endereco;

            if (cliente.Bairro == null)
                cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = cliente.Bairro;

            if (cliente.Cidade == null)
                cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = cliente.Cidade;

            if (cliente.CEP == null)
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = cliente.CEP;

            if (cliente.Estado == null)
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = cliente.Estado;

            if (cliente.Numero == null)
                cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = cliente.Numero;

            if (cliente.Complemento == null)
                cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = cliente.Complemento;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Deletar(int id)
        {
            ConectarSql();
            string query = "DELETE FROM Cliente WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}