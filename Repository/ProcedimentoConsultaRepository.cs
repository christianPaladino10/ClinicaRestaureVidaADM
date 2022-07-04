using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class ProcedimentoConsultaRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        internal void Adicionar(List<ProcedimentoConsulta> listaProcedimentoConsulta)
        {
            ConectarSql();

            string comando = "INSERT INTO ProcedimentoConsulta (ProcedimentoId, ConsultaId) VALUES(@ProcedimentoId, @ConsultaId);";

            foreach (var item in listaProcedimentoConsulta)
            {
                SqlCommand cmd = new SqlCommand(comando, conn);

                cmd.Parameters.Add("@ProcedimentoId", SqlDbType.VarChar).Value = item.IdProcedimento;
                cmd.Parameters.Add("@ConsultaId", SqlDbType.VarChar).Value = item.IdConsulta;

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

        internal List<ProcedimentoConsulta> Buscar(int idConsulta)
        {
            ConectarSql();

            List<ProcedimentoConsulta> listaProcedimentoConsultas = new List<ProcedimentoConsulta>();

            string comando = "SELECT * FROM ProcedimentoConsulta WHERE ConsultaId = @ConsultaId";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@ConsultaId", SqlDbType.Int).Value = idConsulta;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProcedimentoConsulta procedimentoConsulta = new ProcedimentoConsulta();

                procedimentoConsulta.IdConsulta = Convert.ToInt32(reader["ConsultaId"]);
                procedimentoConsulta.IdProcedimento = Convert.ToInt32(reader["ProcedimentoId"]);

                listaProcedimentoConsultas.Add(procedimentoConsulta);
            }

            return listaProcedimentoConsultas;
        }

        internal void Deletar(int idConsulta)
        {
            ConectarSql();

            string comando = "DELETE FROM ProcedimentoConsulta " +
                 "WHERE ConsultaId = @ConsultaId";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@ConsultaId", SqlDbType.VarChar).Value = idConsulta;

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