using AdminRestaureVida.Models;
using AdminRestaureVida.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class ConsultaRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }


        internal int Adicionar(Consulta consulta)
        {
            ConectarSql();

            string comando = "INSERT INTO Consulta (DataCriacao, Observacao, ClienteId, ProfissionalId, Deletado) VALUES(@DataCriacao, @Observacao, @ClienteId, @ProfissionalId, @Deletado);SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@DataCriacao", SqlDbType.VarChar).Value = DateTime.Now;

            if (consulta.Observacao == null)
                cmd.Parameters.Add("@Observacao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Observacao", SqlDbType.VarChar).Value = consulta.Observacao;

            cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = consulta.IdCliente;
            cmd.Parameters.Add("@ProfissionalId", SqlDbType.Int).Value = consulta.ProfissionalId;
            cmd.Parameters.Add("@Deletado", SqlDbType.Bit).Value = 0;

            try
            {
                int idConsulta = Convert.ToInt32(cmd.ExecuteScalar());
                return idConsulta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Consulta> GetConsultasPorCliente(int idCliente)
        {
            ConectarSql();

            string comando = "SELECT * FROM Consulta WHERE ClienteId = @ClienteId AND Deletado = 0";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = idCliente;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Consulta> listaConsulta = new List<Consulta>();

            while (reader.Read())
            {
                Consulta consulta = new Consulta();

                consulta.Id = Convert.ToInt32(reader["Id"]);
                consulta.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
                consulta.DataAtualizacao = reader["DataAtualizacao"] != DBNull.Value ? Convert.ToDateTime(reader["DataAtualizacao"]) : DateTime.MinValue;
                consulta.Observacao = Convert.ToString(reader["Observacao"]);
                consulta.IdCliente = Convert.ToInt32(reader["ClienteId"]);
                consulta.ProfissionalId = Convert.ToInt32(reader["ProfissionalId"]);

                listaConsulta.Add(consulta);
            };

            return listaConsulta;
        }

        internal Consulta Buscar(int id)
        {
            ConectarSql();

            string comando = "SELECT * FROM Consulta WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();

            Consulta consulta = new Consulta();

            while (reader.Read())
            {
                consulta.Id = Convert.ToInt32(reader["Id"]);
                consulta.DataCriacao = reader["DataCriacao"] != DBNull.Value ? Convert.ToDateTime(reader["DataCriacao"]) : DateTime.MinValue;
                consulta.Observacao = Convert.ToString(reader["Observacao"]);
                consulta.IdCliente = Convert.ToInt32(reader["ClienteId"]);
                consulta.ProfissionalId = Convert.ToInt32(reader["ProfissionalId"]);
            };

            return consulta;
        }

        internal void DeletarPorCliente(int idCliente)
        {
            ConectarSql();
            string query = "DELETE FROM Consulta WHERE ClienteId = @idCliente";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

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
            string query = "Update Consulta SET Deletado = 1 WHERE Id = @Id";

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

        internal void Alterar(Consulta consulta)
        {
            ConectarSql();

            string comando = "UPDATE Consulta SET Observacao = @Observacao, DataAtualizacao = @DataAtualizacao " +
                                "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = consulta.Id;

            if (consulta.Observacao == null)
                cmd.Parameters.Add("@Observacao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Observacao", SqlDbType.VarChar).Value = consulta.Observacao;

            cmd.Parameters.Add("@DataAtualizacao", SqlDbType.VarChar).Value = DateTime.Now;

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