using AdminRestaureVida.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminRestaureVida.Repository
{
    public class DiagnosticoRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        internal void Adicionar(Diagnostico diagnostico)
        {
            ConectarSql();

            string comando = "INSERT INTO Diagnostico (Respiratorio, Emocional, Ortopedico,	Digestorio,	MestrualReprodutor,	Cardiovascular,	Observacoes,	Tratamentos,	HorarioCafe,	HorarioAlmoco,	HorarioCafeTarde,	HorarioJantar,	Tatoo,	QtdTatoo,	QntTempoTatoo,	RegiaoTatoo,	Esporte,	QualEsporte,	ProfissionalEsporte,	FrequenciaEsporte,	Medicamento,	QtdMedicamento,	QntTempoMedicamento,	NomeRemedio,	ObjetivoRemedio,	QtdCirurgia,	QntTempoCirurgia,	RegiaoCirurgia,	Transplantado,	QntTempoTransplantado,	OrgaoTransplantado,	Alergico,	ItemAlergico,	ObservacoesAlergicas,	BebidaAlcoolica,	NomeBebida,	QntTempoBebida,	FrequenciaBebida,	MarcaPasso,	QntTempoMarcaPasso,	ObservacaoMarcaPasso,	ProteseSilicone,	QtdProtese,	QntTempoProtese,	RegiaoProtese,	AnimalEstimacao,	QtdAnimalEstimacao,	Raca,	NomeAnimal,	IdadeAnimal,	HistoricoDoencaFamiliar,	ObservacaoGeral,	ClienteId,	ProfissionalId,	DataCriacao, Cirurgia)" +
                                "VALUES(@Respiratorio, @Emocional, @Ortopedico,	@Digestorio,	@MestrualReprodutor,	@Cardiovascular,	@Observacoes,	@Tratamentos,	@HorarioCafe,	@HorarioAlmoco,	@HorarioCafeTarde,	@HorarioJantar,	@Tatoo,	@QtdTatoo,	@QntTempoTatoo,	@RegiaoTatoo,	@Esporte,	@QualEsporte,	@ProfissionalEsporte,	@FrequenciaEsporte,	@Medicamento,	@QtdMedicamento, @QntTempoMedicamento,	@NomeRemedio,	@ObjetivoRemedio,	@QtdCirurgia,	@QntTempoCirurgia,	@RegiaoCirurgia, @Transplantado, @QntTempoTransplantado, @OrgaoTransplantado,	@Alergico,	@ItemAlergico,	@ObservacoesAlergicas,	@BebidaAlcoolica,	@NomeBebida,	@QntTempoBebida,	@FrequenciaBebida,	@MarcaPasso,	@QntTempoMarcaPasso,	@ObservacaoMarcaPasso,	@ProteseSilicone,	@QtdProtese,	@QntTempoProtese,	@RegiaoProtese,	@AnimalEstimacao,	@QtdAnimalEstimacao,	@Raca,	@NomeAnimal,	@IdadeAnimal,	@HistoricoDoencaFamiliar,	@ObservacaoGeral,	@ClienteId,	@ProfissionalId,	@DataCriacao, @Cirurgia)";

            SqlCommand cmd = new SqlCommand(comando, conn);

            #region Atributos

            cmd.Parameters.Add("@ClienteId", SqlDbType.VarChar).Value = diagnostico.IdCliente;

            cmd.Parameters.Add("@ProfissionalId", SqlDbType.VarChar).Value = diagnostico.IdProfissional;

            if (diagnostico.Respiratorio == null)
                cmd.Parameters.Add("@Respiratorio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Respiratorio", SqlDbType.VarChar).Value = diagnostico.Respiratorio;

            if (diagnostico.Emocional == null)
                cmd.Parameters.Add("@Emocional", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Emocional", SqlDbType.VarChar).Value = diagnostico.Emocional;

            if (diagnostico.Ortopedico == null)
                cmd.Parameters.Add("@Ortopedico", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Ortopedico", SqlDbType.VarChar).Value = diagnostico.Ortopedico;

            if (diagnostico.Digestorio == null)
                cmd.Parameters.Add("@Digestorio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Digestorio", SqlDbType.VarChar).Value = diagnostico.Digestorio;

            if (diagnostico.MestrualReprodutor == null)
                cmd.Parameters.Add("@MestrualReprodutor", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@MestrualReprodutor", SqlDbType.VarChar).Value = diagnostico.MestrualReprodutor;

            if (diagnostico.Cardiovascular == null)
                cmd.Parameters.Add("@Cardiovascular", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Cardiovascular", SqlDbType.VarChar).Value = diagnostico.Cardiovascular;

            if (diagnostico.Observacoes == null)
                cmd.Parameters.Add("@Observacoes", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Observacoes", SqlDbType.VarChar).Value = diagnostico.Observacoes;

            if (diagnostico.Tratamentos == null)
                cmd.Parameters.Add("@Tratamentos", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Tratamentos", SqlDbType.VarChar).Value = diagnostico.Tratamentos;

            if (diagnostico.HorarioCafe == null)
                cmd.Parameters.Add("@HorarioCafe", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioCafe", SqlDbType.VarChar).Value = diagnostico.HorarioCafe;

            if (diagnostico.HorarioAlmoco == null)
                cmd.Parameters.Add("@HorarioAlmoco", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioAlmoco", SqlDbType.VarChar).Value = diagnostico.HorarioAlmoco;

            if (diagnostico.HorarioCafeTarde == null)
                cmd.Parameters.Add("@HorarioCafeTarde", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioCafeTarde", SqlDbType.VarChar).Value = diagnostico.HorarioCafeTarde;

            if (diagnostico.HorarioJantar == null)
                cmd.Parameters.Add("@HorarioJantar", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioJantar", SqlDbType.VarChar).Value = diagnostico.HorarioJantar;

            cmd.Parameters.Add("@Tatoo", SqlDbType.Bit).Value = diagnostico.Tatoo;

            if (diagnostico.QtdTatoo == null)
                cmd.Parameters.Add("@QtdTatoo", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdTatoo", SqlDbType.Int).Value = diagnostico.QtdTatoo;

            if (diagnostico.QntTempoTatoo == null)
                cmd.Parameters.Add("@QntTempoTatoo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoTatoo", SqlDbType.VarChar).Value = diagnostico.QntTempoTatoo;

            if (diagnostico.RegiaoTatoo == null)
                cmd.Parameters.Add("@RegiaoTatoo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RegiaoTatoo", SqlDbType.VarChar).Value = diagnostico.RegiaoTatoo;

            cmd.Parameters.Add("@Esporte", SqlDbType.Bit).Value = diagnostico.Esporte;

            if (diagnostico.QualEsporte == null)
                cmd.Parameters.Add("@QualEsporte", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QualEsporte", SqlDbType.VarChar).Value = diagnostico.QualEsporte;

            cmd.Parameters.Add("@ProfissionalEsporte", SqlDbType.Bit).Value = diagnostico.ProfissionalEsporte;

            if (diagnostico.FrequenciaEsporte == null)
                cmd.Parameters.Add("@FrequenciaEsporte", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@FrequenciaEsporte", SqlDbType.VarChar).Value = diagnostico.FrequenciaEsporte;

            cmd.Parameters.Add("@Medicamento", SqlDbType.Bit).Value = diagnostico.Medicamento;

            if (diagnostico.QtdMedicamento == null)
                cmd.Parameters.Add("@QtdMedicamento", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdMedicamento", SqlDbType.Int).Value = diagnostico.QtdMedicamento;

            if (diagnostico.QntTempoMedicamento == null)
                cmd.Parameters.Add("@QntTempoMedicamento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoMedicamento", SqlDbType.VarChar).Value = diagnostico.QntTempoMedicamento;

            if (diagnostico.NomeRemedio == null)
                cmd.Parameters.Add("@NomeRemedio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeRemedio", SqlDbType.VarChar).Value = diagnostico.NomeRemedio;

            if (diagnostico.ObjetivoRemedio == null)
                cmd.Parameters.Add("@ObjetivoRemedio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObjetivoRemedio", SqlDbType.VarChar).Value = diagnostico.ObjetivoRemedio;

            cmd.Parameters.Add("@Cirurgia", SqlDbType.Bit).Value = diagnostico.Cirurgia;

            if (diagnostico.QtdCirurgia == null)
                cmd.Parameters.Add("@QtdCirurgia", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdCirurgia", SqlDbType.Int).Value = diagnostico.QtdCirurgia;

            if (diagnostico.QntTempoCirurgia == null)
                cmd.Parameters.Add("@QntTempoCirurgia", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoCirurgia", SqlDbType.VarChar).Value = diagnostico.QntTempoCirurgia;

            if (diagnostico.RegiaoCirurgia == null)
                cmd.Parameters.Add("@RegiaoCirurgia", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RegiaoCirurgia", SqlDbType.VarChar).Value = diagnostico.RegiaoCirurgia;

            cmd.Parameters.Add("@Transplantado", SqlDbType.Bit).Value = diagnostico.Transplantado;

            if (diagnostico.QntTempoTransplantado == null)
                cmd.Parameters.Add("@QntTempoTransplantado", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoTransplantado", SqlDbType.VarChar).Value = diagnostico.QntTempoTransplantado;

            if (diagnostico.OrgaoTransplantado == null)
                cmd.Parameters.Add("@OrgaoTransplantado", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@OrgaoTransplantado", SqlDbType.VarChar).Value = diagnostico.OrgaoTransplantado;

            cmd.Parameters.Add("@Alergico", SqlDbType.Bit).Value = diagnostico.Alergico;

            if (diagnostico.ItemAlergico == null)
                cmd.Parameters.Add("@ItemAlergico", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ItemAlergico", SqlDbType.VarChar).Value = diagnostico.ItemAlergico;

            if (diagnostico.ObservacoesAlergicas == null)
                cmd.Parameters.Add("@ObservacoesAlergicas", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObservacoesAlergicas", SqlDbType.VarChar).Value = diagnostico.ObservacoesAlergicas;

            cmd.Parameters.Add("@BebidaAlcoolica", SqlDbType.Bit).Value = diagnostico.BebidaAlcoolica;

            if (diagnostico.NomeBebida == null)
                cmd.Parameters.Add("@NomeBebida", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeBebida", SqlDbType.VarChar).Value = diagnostico.NomeBebida;

            if (diagnostico.QntTempoBebida == null)
                cmd.Parameters.Add("@QntTempoBebida", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoBebida", SqlDbType.VarChar).Value = diagnostico.QntTempoBebida;

            if (diagnostico.FrequenciaBebida == null)
                cmd.Parameters.Add("@FrequenciaBebida", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@FrequenciaBebida", SqlDbType.VarChar).Value = diagnostico.FrequenciaBebida;

            cmd.Parameters.Add("@MarcaPasso", SqlDbType.Bit).Value = diagnostico.MarcaPasso;

            if (diagnostico.QntTempoMarcaPasso == null)
                cmd.Parameters.Add("@QntTempoMarcaPasso", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoMarcaPasso", SqlDbType.VarChar).Value = diagnostico.QntTempoMarcaPasso;

            if (diagnostico.ObservacaoMarcaPasso == null)
                cmd.Parameters.Add("@ObservacaoMarcaPasso", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObservacaoMarcaPasso", SqlDbType.VarChar).Value = diagnostico.ObservacaoMarcaPasso;

            cmd.Parameters.Add("@ProteseSilicone", SqlDbType.Bit).Value = diagnostico.ProteseSilicone;

            if (diagnostico.QtdProtese == null)
                cmd.Parameters.Add("@QtdProtese", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdProtese", SqlDbType.Int).Value = diagnostico.QtdProtese;

            if (diagnostico.QntTempoProtese == null)
                cmd.Parameters.Add("@QntTempoProtese", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoProtese", SqlDbType.VarChar).Value = diagnostico.QntTempoProtese;

            if (diagnostico.RegiaoProtese == null)
                cmd.Parameters.Add("@RegiaoProtese", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RegiaoProtese", SqlDbType.VarChar).Value = diagnostico.RegiaoProtese;

            cmd.Parameters.Add("@AnimalEstimacao", SqlDbType.Bit).Value = diagnostico.AnimalEstimacao;

            if (diagnostico.QtdAnimalEstimacao == null)
                cmd.Parameters.Add("@QtdAnimalEstimacao", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdAnimalEstimacao", SqlDbType.Int).Value = diagnostico.QtdAnimalEstimacao;

            if (diagnostico.Raca == null)
                cmd.Parameters.Add("@Raca", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Raca", SqlDbType.VarChar).Value = diagnostico.Raca;

            if (diagnostico.NomeAnimal == null)
                cmd.Parameters.Add("@NomeAnimal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeAnimal", SqlDbType.VarChar).Value = diagnostico.NomeAnimal;

            if (diagnostico.IdadeAnimal == null)
                cmd.Parameters.Add("@IdadeAnimal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IdadeAnimal", SqlDbType.VarChar).Value = diagnostico.IdadeAnimal;

            if (diagnostico.HistoricoDoencaFamiliar == null)
                cmd.Parameters.Add("@HistoricoDoencaFamiliar", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HistoricoDoencaFamiliar", SqlDbType.VarChar).Value = diagnostico.HistoricoDoencaFamiliar;

            if (diagnostico.ObservacaoGeral == null)
                cmd.Parameters.Add("@ObservacaoGeral", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObservacaoGeral", SqlDbType.VarChar).Value = diagnostico.ObservacaoGeral;

            cmd.Parameters.Add("@DataCriacao", SqlDbType.DateTime).Value = DateTime.Now;

            #endregion

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void DeletarPorCliente(int idCliente)
        {
            ConectarSql();
            string query = "DELETE FROM Diagnostico WHERE ClienteId = @idCliente";

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

        internal void Alterar(Diagnostico diagnostico)
        {
            ConectarSql();

            string comando = "UPDATE Diagnostico SET Respiratorio = @Respiratorio,	Emocional = @Emocional,	Ortopedico = @Ortopedico,	Digestorio = @Digestorio,	MestrualReprodutor = @MestrualReprodutor,	Cardiovascular = @Cardiovascular,	Observacoes = @Observacoes,	Tratamentos = @Tratamentos,	HorarioCafe	= @HorarioCafe, HorarioAlmoco = @HorarioAlmoco,	HorarioCafeTarde = @HorarioCafeTarde,	HorarioJantar = @HorarioJantar,	Tatoo = @Tatoo,	QtdTatoo = @QtdTatoo,	QntTempoTatoo = @QntTempoTatoo,	RegiaoTatoo = @RegiaoTatoo,	Esporte	= @Esporte, QualEsporte = @QualEsporte,	ProfissionalEsporte = @ProfissionalEsporte,	FrequenciaEsporte = @FrequenciaEsporte,	Medicamento = @Medicamento,	QtdMedicamento = @QtdMedicamento,	QntTempoMedicamento = @QntTempoMedicamento,	NomeRemedio = @NomeRemedio,	ObjetivoRemedio = @ObjetivoRemedio,	QtdCirurgia = @QtdCirurgia,	QntTempoCirurgia = @QntTempoCirurgia,	RegiaoCirurgia = @RegiaoCirurgia,	Transplantado = @Transplantado,	QntTempoTransplantado = @QntTempoTransplantado,	OrgaoTransplantado = @OrgaoTransplantado,	Alergico = @Alergico,	ItemAlergico = @ItemAlergico,	ObservacoesAlergicas = @ObservacoesAlergicas,	BebidaAlcoolica = @BebidaAlcoolica,	NomeBebida = @NomeBebida,	QntTempoBebida = @QntTempoBebida,	FrequenciaBebida = @FrequenciaBebida,	MarcaPasso = @MarcaPasso,	QntTempoMarcaPasso = @QntTempoMarcaPasso,	ObservacaoMarcaPasso = @ObservacaoMarcaPasso,	ProteseSilicone = @ProteseSilicone,	QtdProtese = @QtdProtese,	QntTempoProtese = @QntTempoProtese,	RegiaoProtese = @RegiaoProtese,	AnimalEstimacao = @AnimalEstimacao,	QtdAnimalEstimacao = @QtdAnimalEstimacao,	Raca = @Raca,	NomeAnimal = @NomeAnimal,	IdadeAnimal = @IdadeAnimal,	HistoricoDoencaFamiliar = @HistoricoDoencaFamiliar,	ObservacaoGeral = @ObservacaoGeral,	 ProfissionalId = @ProfissionalId,	Cirurgia = @Cirurgia, DataAtualizacao = @DataAtualizacao " +
                                 "WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(comando, conn);

            #region Atributos

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = diagnostico.Id;

            cmd.Parameters.Add("@ProfissionalId", SqlDbType.VarChar).Value = diagnostico.IdProfissional;

            if (diagnostico.Respiratorio == null)
                cmd.Parameters.Add("@Respiratorio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Respiratorio", SqlDbType.VarChar).Value = diagnostico.Respiratorio;

            if (diagnostico.Emocional == null)
                cmd.Parameters.Add("@Emocional", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Emocional", SqlDbType.VarChar).Value = diagnostico.Emocional;

            if (diagnostico.Ortopedico == null)
                cmd.Parameters.Add("@Ortopedico", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Ortopedico", SqlDbType.VarChar).Value = diagnostico.Ortopedico;

            if (diagnostico.Digestorio == null)
                cmd.Parameters.Add("@Digestorio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Digestorio", SqlDbType.VarChar).Value = diagnostico.Digestorio;

            if (diagnostico.MestrualReprodutor == null)
                cmd.Parameters.Add("@MestrualReprodutor", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@MestrualReprodutor", SqlDbType.VarChar).Value = diagnostico.MestrualReprodutor;

            if (diagnostico.Cardiovascular == null)
                cmd.Parameters.Add("@Cardiovascular", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Cardiovascular", SqlDbType.VarChar).Value = diagnostico.Cardiovascular;

            if (diagnostico.Observacoes == null)
                cmd.Parameters.Add("@Observacoes", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Observacoes", SqlDbType.VarChar).Value = diagnostico.Observacoes;

            if (diagnostico.Tratamentos == null)
                cmd.Parameters.Add("@Tratamentos", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Tratamentos", SqlDbType.VarChar).Value = diagnostico.Tratamentos;

            if (diagnostico.HorarioCafe == null)
                cmd.Parameters.Add("@HorarioCafe", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioCafe", SqlDbType.VarChar).Value = diagnostico.HorarioCafe;

            if (diagnostico.HorarioAlmoco == null)
                cmd.Parameters.Add("@HorarioAlmoco", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioAlmoco", SqlDbType.VarChar).Value = diagnostico.HorarioAlmoco;

            if (diagnostico.HorarioCafeTarde == null)
                cmd.Parameters.Add("@HorarioCafeTarde", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioCafeTarde", SqlDbType.VarChar).Value = diagnostico.HorarioCafeTarde;

            if (diagnostico.HorarioJantar == null)
                cmd.Parameters.Add("@HorarioJantar", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HorarioJantar", SqlDbType.VarChar).Value = diagnostico.HorarioJantar;

            cmd.Parameters.Add("@Tatoo", SqlDbType.Bit).Value = diagnostico.Tatoo;

            if (diagnostico.QtdTatoo == null)
                cmd.Parameters.Add("@QtdTatoo", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdTatoo", SqlDbType.Int).Value = diagnostico.QtdTatoo;

            if (diagnostico.QntTempoTatoo == null)
                cmd.Parameters.Add("@QntTempoTatoo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoTatoo", SqlDbType.VarChar).Value = diagnostico.QntTempoTatoo;

            if (diagnostico.RegiaoTatoo == null)
                cmd.Parameters.Add("@RegiaoTatoo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RegiaoTatoo", SqlDbType.VarChar).Value = diagnostico.RegiaoTatoo;

            cmd.Parameters.Add("@Esporte", SqlDbType.Bit).Value = diagnostico.Esporte;

            if (diagnostico.QualEsporte == null)
                cmd.Parameters.Add("@QualEsporte", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QualEsporte", SqlDbType.VarChar).Value = diagnostico.QualEsporte;

            cmd.Parameters.Add("@ProfissionalEsporte", SqlDbType.Bit).Value = diagnostico.ProfissionalEsporte;

            if (diagnostico.FrequenciaEsporte == null)
                cmd.Parameters.Add("@FrequenciaEsporte", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@FrequenciaEsporte", SqlDbType.VarChar).Value = diagnostico.FrequenciaEsporte;

            cmd.Parameters.Add("@Medicamento", SqlDbType.Bit).Value = diagnostico.Medicamento;

            if (diagnostico.QtdMedicamento == null)
                cmd.Parameters.Add("@QtdMedicamento", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdMedicamento", SqlDbType.Int).Value = diagnostico.QtdMedicamento;

            if (diagnostico.QntTempoMedicamento == null)
                cmd.Parameters.Add("@QntTempoMedicamento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoMedicamento", SqlDbType.VarChar).Value = diagnostico.QntTempoMedicamento;

            if (diagnostico.NomeRemedio == null)
                cmd.Parameters.Add("@NomeRemedio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeRemedio", SqlDbType.VarChar).Value = diagnostico.NomeRemedio;

            if (diagnostico.ObjetivoRemedio == null)
                cmd.Parameters.Add("@ObjetivoRemedio", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObjetivoRemedio", SqlDbType.VarChar).Value = diagnostico.ObjetivoRemedio;

            cmd.Parameters.Add("@Cirurgia", SqlDbType.Bit).Value = diagnostico.Cirurgia;

            if (diagnostico.QtdCirurgia == null)
                cmd.Parameters.Add("@QtdCirurgia", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdCirurgia", SqlDbType.Int).Value = diagnostico.QtdCirurgia;

            if (diagnostico.QntTempoCirurgia == null)
                cmd.Parameters.Add("@QntTempoCirurgia", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoCirurgia", SqlDbType.VarChar).Value = diagnostico.QntTempoCirurgia;

            if (diagnostico.RegiaoCirurgia == null)
                cmd.Parameters.Add("@RegiaoCirurgia", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RegiaoCirurgia", SqlDbType.VarChar).Value = diagnostico.RegiaoCirurgia;

            cmd.Parameters.Add("@Transplantado", SqlDbType.Bit).Value = diagnostico.Transplantado;

            if (diagnostico.QntTempoTransplantado == null)
                cmd.Parameters.Add("@QntTempoTransplantado", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoTransplantado", SqlDbType.VarChar).Value = diagnostico.QntTempoTransplantado;

            if (diagnostico.OrgaoTransplantado == null)
                cmd.Parameters.Add("@OrgaoTransplantado", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@OrgaoTransplantado", SqlDbType.VarChar).Value = diagnostico.OrgaoTransplantado;

            cmd.Parameters.Add("@Alergico", SqlDbType.Bit).Value = diagnostico.Alergico;

            if (diagnostico.ItemAlergico == null)
                cmd.Parameters.Add("@ItemAlergico", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ItemAlergico", SqlDbType.VarChar).Value = diagnostico.ItemAlergico;

            if (diagnostico.ObservacoesAlergicas == null)
                cmd.Parameters.Add("@ObservacoesAlergicas", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObservacoesAlergicas", SqlDbType.VarChar).Value = diagnostico.ObservacoesAlergicas;

            cmd.Parameters.Add("@BebidaAlcoolica", SqlDbType.Bit).Value = diagnostico.BebidaAlcoolica;

            if (diagnostico.NomeBebida == null)
                cmd.Parameters.Add("@NomeBebida", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeBebida", SqlDbType.VarChar).Value = diagnostico.NomeBebida;

            if (diagnostico.QntTempoBebida == null)
                cmd.Parameters.Add("@QntTempoBebida", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoBebida", SqlDbType.VarChar).Value = diagnostico.QntTempoBebida;

            if (diagnostico.FrequenciaBebida == null)
                cmd.Parameters.Add("@FrequenciaBebida", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@FrequenciaBebida", SqlDbType.VarChar).Value = diagnostico.FrequenciaBebida;

            cmd.Parameters.Add("@MarcaPasso", SqlDbType.Bit).Value = diagnostico.MarcaPasso;

            if (diagnostico.QntTempoMarcaPasso == null)
                cmd.Parameters.Add("@QntTempoMarcaPasso", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoMarcaPasso", SqlDbType.VarChar).Value = diagnostico.QntTempoMarcaPasso;

            if (diagnostico.ObservacaoMarcaPasso == null)
                cmd.Parameters.Add("@ObservacaoMarcaPasso", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObservacaoMarcaPasso", SqlDbType.VarChar).Value = diagnostico.ObservacaoMarcaPasso;

            cmd.Parameters.Add("@ProteseSilicone", SqlDbType.Bit).Value = diagnostico.ProteseSilicone;

            if (diagnostico.QtdProtese == null)
                cmd.Parameters.Add("@QtdProtese", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdProtese", SqlDbType.Int).Value = diagnostico.QtdProtese;

            if (diagnostico.QntTempoProtese == null)
                cmd.Parameters.Add("@QntTempoProtese", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QntTempoProtese", SqlDbType.VarChar).Value = diagnostico.QntTempoProtese;

            if (diagnostico.RegiaoProtese == null)
                cmd.Parameters.Add("@RegiaoProtese", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RegiaoProtese", SqlDbType.VarChar).Value = diagnostico.RegiaoProtese;

            cmd.Parameters.Add("@AnimalEstimacao", SqlDbType.Bit).Value = diagnostico.AnimalEstimacao;

            if (diagnostico.QtdAnimalEstimacao == null)
                cmd.Parameters.Add("@QtdAnimalEstimacao", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@QtdAnimalEstimacao", SqlDbType.Int).Value = diagnostico.QtdAnimalEstimacao;

            if (diagnostico.Raca == null)
                cmd.Parameters.Add("@Raca", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Raca", SqlDbType.VarChar).Value = diagnostico.Raca;

            if (diagnostico.NomeAnimal == null)
                cmd.Parameters.Add("@NomeAnimal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@NomeAnimal", SqlDbType.VarChar).Value = diagnostico.NomeAnimal;

            if (diagnostico.IdadeAnimal == null)
                cmd.Parameters.Add("@IdadeAnimal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@IdadeAnimal", SqlDbType.VarChar).Value = diagnostico.IdadeAnimal;

            if (diagnostico.HistoricoDoencaFamiliar == null)
                cmd.Parameters.Add("@HistoricoDoencaFamiliar", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@HistoricoDoencaFamiliar", SqlDbType.VarChar).Value = diagnostico.HistoricoDoencaFamiliar;

            if (diagnostico.ObservacaoGeral == null)
                cmd.Parameters.Add("@ObservacaoGeral", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ObservacaoGeral", SqlDbType.VarChar).Value = diagnostico.ObservacaoGeral;

            cmd.Parameters.Add("@DataAtualizacao", SqlDbType.DateTime).Value = DateTime.Now;

            #endregion

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Diagnostico BuscarDiagnostico(int clienteId)
        {
            ConectarSql();

            string comando = "SELECT * FROM Diagnostico WHERE ClienteId = @clienteId";
            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@clienteId", SqlDbType.Int).Value = clienteId;

            SqlDataReader reader = cmd.ExecuteReader();

            Diagnostico diagnostico = new Diagnostico();

            while (reader.Read())
            {
                diagnostico.Id = Convert.ToInt32(reader["Id"]);
                diagnostico.Respiratorio = Convert.ToString(reader["Respiratorio"]);
                diagnostico.Emocional = Convert.ToString(reader["Emocional"]);
                diagnostico.Ortopedico = Convert.ToString(reader["Ortopedico"]);
                diagnostico.Digestorio = Convert.ToString(reader["Digestorio"]);
                diagnostico.MestrualReprodutor = Convert.ToString(reader["MestrualReprodutor"]);
                diagnostico.Cardiovascular = Convert.ToString(reader["Cardiovascular"]);
                diagnostico.Observacoes = Convert.ToString(reader["Observacoes"]);
                diagnostico.Tratamentos = Convert.ToString(reader["Tratamentos"]);
                diagnostico.HorarioCafe = Convert.ToString(reader["HorarioCafe"]);
                diagnostico.HorarioAlmoco = Convert.ToString(reader["HorarioAlmoco"]);
                diagnostico.HorarioCafeTarde = Convert.ToString(reader["HorarioCafeTarde"]);
                diagnostico.HorarioJantar = Convert.ToString(reader["HorarioJantar"]);
                diagnostico.Tatoo = Convert.ToBoolean(reader["Tatoo"]);
                diagnostico.QtdTatoo = !string.IsNullOrEmpty(reader["QtdTatoo"].ToString()) ? Convert.ToInt32(reader["QtdTatoo"]) : 0;
                diagnostico.QntTempoTatoo = Convert.ToString(reader["QntTempoTatoo"]);
                diagnostico.RegiaoTatoo = Convert.ToString(reader["RegiaoTatoo"]);
                diagnostico.Esporte = Convert.ToBoolean(reader["Esporte"]);
                diagnostico.QualEsporte = Convert.ToString(reader["QualEsporte"]);
                diagnostico.ProfissionalEsporte = Convert.ToBoolean(reader["ProfissionalEsporte"]);
                diagnostico.FrequenciaEsporte = Convert.ToString(reader["FrequenciaEsporte"]);
                diagnostico.Medicamento = Convert.ToBoolean(reader["Medicamento"]);
                diagnostico.QtdMedicamento = !string.IsNullOrEmpty(reader["QtdMedicamento"].ToString()) ? Convert.ToInt32(reader["QtdMedicamento"]) : 0;
                diagnostico.QntTempoMedicamento = Convert.ToString(reader["QntTempoMedicamento"]);
                diagnostico.NomeRemedio = Convert.ToString(reader["NomeRemedio"]);
                diagnostico.ObjetivoRemedio = Convert.ToString(reader["ObjetivoRemedio"]);
                diagnostico.Cirurgia = Convert.ToBoolean(reader["Cirurgia"]);
                diagnostico.QtdCirurgia = !string.IsNullOrEmpty(reader["QtdCirurgia"].ToString()) ? Convert.ToInt32(reader["QtdCirurgia"]) : 0;
                diagnostico.QntTempoCirurgia = Convert.ToString(reader["QntTempoCirurgia"]);
                diagnostico.RegiaoCirurgia = Convert.ToString(reader["RegiaoCirurgia"]);
                diagnostico.Transplantado = Convert.ToBoolean(reader["Transplantado"]);
                diagnostico.QntTempoTransplantado = Convert.ToString(reader["QntTempoTransplantado"]);
                diagnostico.OrgaoTransplantado = Convert.ToString(reader["OrgaoTransplantado"]);
                diagnostico.Alergico = Convert.ToBoolean(reader["Alergico"]);
                diagnostico.ItemAlergico = Convert.ToString(reader["ItemAlergico"]);
                diagnostico.ObservacoesAlergicas = Convert.ToString(reader["ObservacoesAlergicas"]);
                diagnostico.BebidaAlcoolica = Convert.ToBoolean(reader["BebidaAlcoolica"]);
                diagnostico.NomeBebida = Convert.ToString(reader["NomeBebida"]);
                diagnostico.QntTempoBebida = Convert.ToString(reader["QntTempoBebida"]);
                diagnostico.FrequenciaBebida = Convert.ToString(reader["FrequenciaBebida"]);
                diagnostico.MarcaPasso = Convert.ToBoolean(reader["MarcaPasso"]);
                diagnostico.QntTempoMarcaPasso = Convert.ToString(reader["QntTempoMarcaPasso"]);
                diagnostico.ObservacaoMarcaPasso = Convert.ToString(reader["ObservacaoMarcaPasso"]);
                diagnostico.ProteseSilicone = Convert.ToBoolean(reader["ProteseSilicone"]);
                diagnostico.QtdProtese = !string.IsNullOrEmpty(reader["QtdProtese"].ToString()) ? Convert.ToInt32(reader["QtdProtese"]) : 0;
                diagnostico.QntTempoProtese = Convert.ToString(reader["QntTempoProtese"]);
                diagnostico.RegiaoProtese = Convert.ToString(reader["RegiaoProtese"]);
                diagnostico.AnimalEstimacao = Convert.ToBoolean(reader["AnimalEstimacao"]);
                diagnostico.QtdAnimalEstimacao = !string.IsNullOrEmpty(reader["QtdAnimalEstimacao"].ToString()) ? Convert.ToInt32(reader["QtdAnimalEstimacao"]) : 0;
                diagnostico.Raca = Convert.ToString(reader["Raca"]);
                diagnostico.NomeAnimal = Convert.ToString(reader["NomeAnimal"]);
                diagnostico.IdadeAnimal = Convert.ToString(reader["IdadeAnimal"]);
                diagnostico.HistoricoDoencaFamiliar = Convert.ToString(reader["HistoricoDoencaFamiliar"]);
                diagnostico.ObservacaoGeral = Convert.ToString(reader["ObservacaoGeral"]);
                diagnostico.IdCliente = Convert.ToInt32(reader["ClienteId"]);
                diagnostico.IdProfissional = Convert.ToInt32(reader["ProfissionalId"]);
                diagnostico.DataCriacao = Convert.ToDateTime(reader["DataCriacao"]);
            }

            return diagnostico;
        }

    }
}