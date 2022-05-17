using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class SegmentoRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        public List<Segmento> BuscarTodos()
        {
            List<Segmento> listaSegmento = new List<Segmento>();
            ConectarSql();

            string comando = "SELECT * FROM Segmento";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Segmento segmento = new Segmento();

                segmento.Id = Convert.ToInt32(reader["Id"]);
                segmento.Nome = Convert.ToString(reader["Nome"]);
                segmento.Descricao = Convert.ToString(reader["Descricao"]);

                listaSegmento.Add(segmento);
            }

            return listaSegmento;
        }

        internal void Adicionar(Segmento segmento)
        {
            ConectarSql();

            string comando = "INSERT INTO Segmento (Nome, Descricao) VALUES(@Nome, @Descricao)";

            SqlCommand cmd = new SqlCommand(comando, conn);

            if (segmento.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = segmento.Nome;

            if(segmento.Descricao == null)
                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = segmento.Descricao;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Alterar(Segmento segmento)
        {
            ConectarSql();

            string comando = "UPDATE Segmento SET  Nome = @Nome, Descricao = @Descricao " +
                                "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = segmento.Id;

            if (segmento.Nome == null)
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = segmento.Nome;

            if (segmento.Descricao == null)
                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = segmento.Descricao;

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
            string query = "DELETE FROM Segmento WHERE Id = @Id";

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

        public Segmento Buscar(int id)
        {
            ConectarSql();

            string comando = "SELECT * FROM Segmento WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();

            Segmento Segmento = new Segmento();

            while (reader.Read())
            {
                Segmento.Id = Convert.ToInt32(reader["Id"]);
                Segmento.Nome = Convert.ToString(reader["Nome"]);
                Segmento.Descricao = Convert.ToString(reader["Descricao"]);
            }

            return Segmento;
        }
    }
}