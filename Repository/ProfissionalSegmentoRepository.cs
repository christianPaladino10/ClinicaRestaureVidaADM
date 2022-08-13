using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class ProfissionalSegmentoRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        internal void Adicionar(List<ProfissionalSegmento> listaProfissionalSegmento)
        {
            ConectarSql();

            string comando = "INSERT INTO ProfissionalSegmento (ProfissionalId, SegmentoId) VALUES(@ProfissionalId, @SegmentoId);";

            foreach (var item in listaProfissionalSegmento)
            {
                SqlCommand cmd = new SqlCommand(comando, conn);

                cmd.Parameters.Add("@ProfissionalId", SqlDbType.Int).Value = item.ProfissionalId;
                cmd.Parameters.Add("@SegmentoId", SqlDbType.Int).Value = item.SegmentoId;

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

        internal List<ProfissionalSegmento> Buscar(int idProfissional)
        {
            ConectarSql();

            List<ProfissionalSegmento> listaProfissionalSegmento = new List<ProfissionalSegmento>();

            string comando = "SELECT * FROM ProfissionalSegmento WHERE ProfissionalId = @ProfissionalId";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@ProfissionalId", SqlDbType.Int).Value = idProfissional;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProfissionalSegmento profissionalSegmento = new ProfissionalSegmento();

                profissionalSegmento.ProfissionalId = Convert.ToInt32(reader["ProfissionalId"]);
                profissionalSegmento.SegmentoId = Convert.ToInt32(reader["SegmentoId"]);

                listaProfissionalSegmento.Add(profissionalSegmento);
            }

            return listaProfissionalSegmento;
        }

        internal void Deletar(int idProfissional)
        {
            ConectarSql();

            string comando = "DELETE FROM ProfissionalSegmento " +
                 "WHERE ProfissionalId = @ProfissionalId";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@ProfissionalId", SqlDbType.Int).Value = idProfissional;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void DeletarPorIdSegmento(int idSegmento)
        {
            ConectarSql();

            string comando = "DELETE FROM ProfissionalSegmento " +
                 "WHERE SegmentoId = @SegmentoId";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@SegmentoId", SqlDbType.Int).Value = idSegmento;

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