using FluentValidation.Results;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Dominio.ModuloQuestao;
using TesteMariana.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.Compartilhado;

namespace TesteMariana.Infra.BancoDados.ModuloMateria
{
    public class RepositorioQuestaoEmBancoDados : IRepositorioQuestao
    {

        private const string enderecoBanco =
                 "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                 "Initial Catalog=MarianaDb;" +
                 "Integrated Security=True;" +
                 "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
        @"INSERT INTO [TBQuestao]
           (
            [TITULO]
           ,[DISCIPLINA_NUMERO]
           ,[MATERIA_NUMERO])
        VALUES
           (@TITULO
           ,@DISCIPLINA_NUMERO
           ,@MATERIA_NUMERO);
            SELECT SCOPE_IDENTITY();";
        private const string sqlInserirAlternativa =
        @"INSERT INTO [TBAlternativa]
           (
            [NUMERO_QUESTAO]
           ,[LETRA]
           ,[CORRETA]
           ,[RESPOSTA])
        VALUES
           (@NUMERO_QUESTAO
           ,@LETRA
           ,@CORRETA
           ,@RESPOSTA);
            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
           @"UPDATE [TBQuestao]	
		        SET
			       [TITULO] = @TITULO,
			       [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO,
                   [MATERIA_NUMERO] = @MATERIA_NUMERO
		        WHERE
			        [NUMERO] = @NUMERO";
        private const string sqlExcluirAlternativa =
        @"DELETE FROM [TBAlternativa]
            WHERE
                [NUMERO_QUESTAO] = @NUMERO_QUESTAO";

        private const string sqlExcluir =
            @"DELETE FROM [TBQuestao]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
           @"SELECT 
                Q.NUMERO,
                Q.TITULO,
                Q.DISCIPLINA_NUMERO,
                Q.MATERIA_NUMERO,
                   
                D.NUMERO AS DISCIPLINA_NUMERO,
		        D.TITULO AS DISCIPLINA_TITULO,

                M.NUMERO AS MATERIA_NUMERO,
                M.TITULO AS MATERIA_TITULO,
                M.SERIE AS MATERIA_SERIE
            FROM 
                TBQuestao AS Q INNER JOIN 
                TBDisciplina AS D ON
                Q.[DISCIPLINA_NUMERO] = D.NUMERO
                INNER JOIN TBMateria as M ON
                Q.[MATERIA_NUMERO] = M.[NUMERO]            
    ";


        private const string sqlSelecionarPorNumero =
           @"SELECT 
		        Q.[NUMERO], 
		        Q.[TITULO],
                Q.[DISCIPLINA_NUMERO],
                Q.[MATERIA_NUMERO],

				D.[NUMERO] AS DISCIPLINA_NUMERO,
                D.[TITULO] AS DISCIPLINA_TITULO,
        
                M.NUMERO AS MATERIA_NUMERO,
                M.TITULO AS MATERIA_TITULO,                                    
                M.SERIE AS MATERIA_SERIE

            FROM 
		        TBQuestao AS Q INNER JOIN 
                TBDisciplina AS D ON 
                Q.[DISCIPLINA_NUMERO] = D.NUMERO 
                INNER JOIN TBMateria as M ON
                Q.[MATERIA_NUMERO] = M.[NUMERO]

		        WHERE
                    Q.[NUMERO] = @NUMERO";

        #endregion
        public ValidationResult Inserir(Questao questao)
        {
            var validador = new ValidadorQuestao();

            var resultadoValidacao = validador.Validate(questao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            SqlCommand comandoInsercaoAlternativa = 
                new SqlCommand(sqlInserirAlternativa, conexaoComBanco);

            ConfigurarParametrosQuestao(questao, comandoInsercao);

            conexaoComBanco.Open();
            var _id = comandoInsercao.ExecuteScalar();
            int id = Convert.ToInt32(_id);
            questao.Id = id;
                foreach (var alternativa in questao.alternativas)
                {
                    alternativa.Id = id;
                    ConfigurarParametrosAlternativa(alternativa, comandoInsercaoAlternativa);
                    comandoInsercaoAlternativa.ExecuteScalar();
                    comandoInsercaoAlternativa.Parameters.Clear();
                }
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Editar(Questao questao)
        {
            var validador = new ValidadorQuestao();

            var resultadoValidacao = validador.Validate(questao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            SqlCommand comandoExcluirAlternativa = new SqlCommand(sqlExcluirAlternativa, conexaoComBanco);
            SqlCommand comandoInserirAlternativa = new SqlCommand(sqlInserirAlternativa, conexaoComBanco);


            conexaoComBanco.Open();

            comandoExcluirAlternativa.Parameters.AddWithValue("NUMERO_QUESTAO", questao.Id);
            comandoExcluirAlternativa.ExecuteNonQuery();

            ConfigurarParametrosQuestao(questao, comandoEdicao);

            foreach (var alternativa in questao.alternativas)
            {
                alternativa.Id = questao.Id;
                ConfigurarParametrosAlternativa(alternativa, comandoInserirAlternativa);
                comandoInserirAlternativa.ExecuteNonQuery();
                comandoInserirAlternativa.Parameters.Clear();
            }
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Excluir(Questao questao)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            SqlCommand comandoExclusaoAlternativa = new SqlCommand(sqlExcluirAlternativa, conexaoComBanco);

            comandoExclusaoAlternativa.Parameters.AddWithValue("NUMERO_QUESTAO", questao.Id);

            comandoExclusao.Parameters.AddWithValue("NUMERO", questao.Id);

            conexaoComBanco.Open();
            comandoExclusaoAlternativa.ExecuteNonQuery();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public List<Questao> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestao = comandoSelecao.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestao.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestao);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }
        public Questao SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Questao questao = null;
            if (leitorMateria.Read())
                questao = ConverterParaQuestao(leitorMateria);

            conexaoComBanco.Close();

            return questao;
        }
        private static Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            int numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            string titulo = Convert.ToString(leitorQuestao["TITULO"]);

            int numeroDisciplina = Convert.ToInt32(leitorQuestao["DISCIPLINA_NUMERO"]);
            string nomeDisciplina = Convert.ToString(leitorQuestao["DISCIPLINA_TITULO"]);

            int numeroMateria = Convert.ToInt32(leitorQuestao["MATERIA_NUMERO"]);
            string nomeMateria = Convert.ToString(leitorQuestao["MATERIA_TITULO"]);
            int serieMateria = Convert.ToInt32(leitorQuestao["MATERIA_SERIE"]);

            var questao = new Questao
            {
                Id = numero,
                Nome = titulo,
                disciplina = new Disciplina
                {
                    Id = numeroDisciplina,
                    Nome = nomeDisciplina
                },
                materia = new Materia
                { 
                    Id = numeroMateria,
                    Nome = nomeMateria,
                    Serie = (SerieEnum)serieMateria
                },
                
                alternativas = new List<Alternativas> ()                                    
            };

            return questao;
        }
        private static void ConfigurarParametrosQuestao(Questao questao, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("NUMERO", questao.Id);
            comandoInsercao.Parameters.AddWithValue("TITULO", questao.Nome);
            comandoInsercao.Parameters.AddWithValue("DISCIPLINA_NUMERO", questao.disciplina.Id);
            comandoInsercao.Parameters.AddWithValue("MATERIA_NUMERO", questao.materia.Id);

        }
        private static void ConfigurarParametrosAlternativa
            (Alternativas alternativa, SqlCommand comandoInsercao)
        {            
            comandoInsercao.Parameters.AddWithValue("NUMERO_QUESTAO", alternativa.Id);
            comandoInsercao.Parameters.AddWithValue("LETRA", alternativa.letra);
            comandoInsercao.Parameters.AddWithValue("CORRETA", alternativa.Correta);
            comandoInsercao.Parameters.AddWithValue("RESPOSTA", alternativa.Resposta);            
        }
    }
}
