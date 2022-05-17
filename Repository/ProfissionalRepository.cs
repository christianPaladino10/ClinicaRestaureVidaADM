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

            string comando = "SELECT * FROM Profissional";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Profissional profissional = new Profissional();

                profissional.Id = Convert.ToInt32(reader["Id"]);
                profissional.Nome = Convert.ToString(reader["Nome"]);
                profissional.SegmentoId = Convert.ToInt32(reader["SegmentoId"]);

                listaProfissionais.Add(profissional);
            }

            return listaProfissionais;
        }

        internal void Adicionar(Profissional profissional)
        {
            ConectarSql();

            string comando = "INSERT INTO Profissional (Nome, DataNascimento, CPF, Celular, Telefone, DataCadastro, SegmentoId) VALUES(@Nome, @DataNascimento, @CPF, @Celular, @Telefone, @DataCadastro, @SegmentoId)";

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

            cmd.Parameters.Add("@DataCadastro", SqlDbType.VarChar).Value = DateTime.Now;

            cmd.Parameters.Add("@SegmentoId", SqlDbType.VarChar).Value = profissional.SegmentoId;

            try
            {
                cmd.ExecuteNonQuery();
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
            string query = "DELETE FROM Profissional WHERE Id = @Id";

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

            string comando = "SELECT * FROM Profissional WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();

            Profissional profissional = new Profissional();

            while (reader.Read())
            {
                profissional.Id = Convert.ToInt32(reader["Id"]);
                profissional.Nome = Convert.ToString(reader["Nome"]);
                profissional.SegmentoId = Convert.ToInt32(reader["SegmentoId"]);
                profissional.DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : DateTime.MinValue;
                profissional.CPF = Convert.ToString(reader["CPF"]);
                profissional.Celular = Convert.ToString(reader["Celular"]);
                profissional.Telefone = Convert.ToString(reader["Telefone"]);
            }

            return profissional;
        }
    }
}