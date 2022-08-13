using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class ProfissionalRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        public List<Profissional> BuscarTodos()
        {
            List<Profissional> listaProfissionais = new List<Profissional>();
            ConectarSql();

            string comando = "SELECT * FROM Profissional WHERE Deletado = 0";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Profissional profissional = new Profissional();

                profissional.Id = Convert.ToInt32(reader["Id"]);
                profissional.Nome = Convert.ToString(reader["Nome"]);

                listaProfissionais.Add(profissional);
            }

            return listaProfissionais;
        }

        internal int Adicionar(Profissional profissional)
        {
            ConectarSql();

            string comando = "INSERT INTO Profissional (Nome, DataNascimento, CPF, Celular, Telefone, DataCadastro, Email, Senha) VALUES(@Nome, @DataNascimento, @CPF, @Celular, @Telefone, @DataCadastro, @Email, @Senha);SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(comando, conn);

            if (profissional.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = profissional.Nome;

            if (profissional.DataNascimento == null)
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = profissional.DataNascimento;

            if (profissional.CPF == null)
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = profissional.CPF;

            if (profissional.Celular == null)
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = profissional.Celular;

            if (profissional.Telefone == null)
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = profissional.Telefone;

            cmd.Parameters.Add("@DataCadastro", SqlDbType.DateTime).Value = DateTime.Now;

            if (profissional.Email == null)
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = profissional.Email;

            if (profissional.Senha == null)
                cmd.Parameters.Add("@Senha", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Senha", SqlDbType.VarChar).Value = profissional.Senha;

            try
            {
                int idProfissional = Convert.ToInt32(cmd.ExecuteScalar());
                return idProfissional;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Alterar(Profissional profissional)
        {
            ConectarSql();

            string comando = "UPDATE Profissional SET  Nome = @Nome, DataNascimento = @DataNascimento, CPF = @CPF, Celular = @Celular, Telefone = @Telefone " +
                                "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = profissional.Id;

            if (profissional.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = profissional.Nome;

            if (profissional.DataNascimento == null)
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = profissional.DataNascimento;

            if (profissional.CPF == null)
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = profissional.CPF;

            if (profissional.Celular == null)
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = profissional.Celular;

            if (profissional.Telefone == null)
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = profissional.Telefone;

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
            string query = "Update Profissional SET Deletado = 1 WHERE Id = @Id";

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

        public Profissional Buscar(int id)
        {
            ConectarSql();

            string comando = "SELECT * FROM Profissional WHERE Id = @Id AND Deletado = 0";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();

            Profissional profissional = new Profissional();

            while (reader.Read())
            {
                profissional.Id = Convert.ToInt32(reader["Id"]);
                profissional.Nome = Convert.ToString(reader["Nome"]);
                profissional.DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : DateTime.MinValue;
                profissional.CPF = Convert.ToString(reader["CPF"]);
                profissional.Celular = Convert.ToString(reader["Celular"]);
                profissional.Telefone = Convert.ToString(reader["Telefone"]);
                profissional.DataCadastro = reader["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(reader["DataCadastro"]) : DateTime.MinValue;
            }

            return profissional;
        }

        public Profissional Login(Profissional profissional)
        {
            ConectarSql();

            string comando = "SELECT * FROM Profissional WHERE Email = @Email and Senha = @Senha AND Deletado = 0";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = profissional.Email;
            cmd.Parameters.Add("@Senha", SqlDbType.VarChar).Value = profissional.Senha;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                profissional.Id = Convert.ToInt32(reader["Id"]);
                profissional.Nome = Convert.ToString(reader["Nome"]);
                profissional.DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : DateTime.MinValue;
                profissional.CPF = Convert.ToString(reader["CPF"]);
                profissional.Celular = Convert.ToString(reader["Celular"]);
                profissional.Telefone = Convert.ToString(reader["Telefone"]);
            }

            return profissional;
        }

    }
}