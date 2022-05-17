using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class ProcedimentoRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        public List<Procedimento> BuscarTodos()
        {
            List<Procedimento> listaProcedimentos = new List<Procedimento>();
            ConectarSql();

            string comando = "SELECT * FROM Procedimento";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Procedimento procedimento = new Procedimento();

                procedimento.Id = Convert.ToInt32(reader["Id"]);
                procedimento.Nome = Convert.ToString(reader["Nome"]);

                listaProcedimentos.Add(procedimento);
            }

            return listaProcedimentos;
        }

        internal void Adicionar(Procedimento procedimento)
        {
            ConectarSql();

            string comando = "INSERT INTO Procedimento (Nome) VALUES(@Nome)";

            SqlCommand cmd = new SqlCommand(comando, conn);

            if (procedimento.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = procedimento.Nome;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Alterar(Procedimento procedimento)
        {
            ConectarSql();

            string comando = "UPDATE Procedimento SET  Nome = @Nome " +
                                "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = procedimento.Id;

            if (procedimento.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = procedimento.Nome;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal void Deletar(int id)
        {
            ConectarSql();
            string query = "DELETE FROM Procedimento WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Procedimento Buscar(int id)
        {
            ConectarSql();

            string comando = "SELECT * FROM Procedimento WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();

            Procedimento procedimento = new Procedimento();

            while (reader.Read())
            {
                procedimento.Id = Convert.ToInt32(reader["Id"]);
                procedimento.Nome = Convert.ToString(reader["Nome"]);
            }

            return procedimento;
        }

    }
}