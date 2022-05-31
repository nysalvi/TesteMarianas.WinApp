using FluentValidation.Results;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Dominio.ModuloQuestao;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.Compartilhado;

namespace TesteMariana.Infra.BancoDados.ModuloTeste
{
    public class RepositorioTesteEmBancoDados : IRepositorioTeste
    {
        private const string enderecoBanco =
                 "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                 "Initial Catalog=MarianaDb;" +
                 "Integrated Security=True;" +
                 "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
        @"INSERT INTO [TBTeste]
           (
            [TITULO],
            [NUMERO_MATERIA],
            [NUMERO_DISCIPLINA],
            [DATA],
            [PROVAO])
        VALUES
           (@[TITULO],
            @[NUMERO_MATERIA],
            @[NUMERO_DISCIPLINA],
            @[DATA],
            @[PROVAO]);
            SELECT SCOPE_IDENTITY();";


        private const string sqlEditar =
           @"UPDATE [TBTeste]	
		        SET
                    [TITULO] = @TITULO,
                    [NUMERO_DISCIPLINA] = @NUMERO_DISCIPLINA,
                    [NUMERO_MATERIA] = @NUMERO_MATERIA,
                    [DATA] = @DATA,
                    [PROVAO] = @PROVAO
		        WHERE
			        [NUMERO] = @NUMERO";
        const string sqlInserirTesteQuestao =
        @"INSERT INTO [TBTeste_Questao]
           (
            [NUMERO_TESTE],
            [NUMERO_QUESTAO])
        VALUES
           (@[NUMERO_TESTE],
            @[NUMERO_QUESTAO])
            SELECT SCOPE_IDENTITY();";
        private const string sqlExcluirTesteQuestao =
        @"DELETE FROM [TBTeste_Questao]
            WHERE
                [NUMERO_TESTE] = @NUMERO_TESTE";

        private const string sqlExcluir =
            @"DELETE FROM [TBTeste]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
           @"SELECT 
                T.NUMERO,
                T.TITULO,
                T.DISCIPLINA_NUMERO,
                T.MATERIA_NUMERO,
                   
		        D.TITULO AS DISCIPLINA_TITULO,
                
                M.TITULO AS MATERIA_TITULO,
                M.SERIE AS MATERIA_SERIE
            FROM 
                TBTeste AS T INNER JOIN 
                TBDisciplina AS D ON
                T.[DISCIPLINA_NUMERO] = D.NUMERO
                INNER JOIN TBMateria as M ON
                T.[MATERIA_NUMERO] = M.[NUMERO]            
    ";


        private const string sqlSelecionarPorNumero =
           @"SELECT 
		        T.[NUMERO], 
		        T.[TITULO],
                T.[DISCIPLINA_NUMERO],
                T.[MATERIA_NUMERO],

                D.[TITULO] AS DISCIPLINA_TITULO,
        
                M.NUMERO AS MATERIA_NUMERO,
                M.TITULO AS MATERIA_TITULO,                                    
                M.SERIE AS MATERIA_SERIE

            FROM 
		        TBTeste AS T INNER JOIN 
                TBDisciplina AS D ON 
                T.[DISCIPLINA_NUMERO] = D.NUMERO 
                INNER JOIN TBMateria as M ON
                T.[MATERIA_NUMERO] = M.[NUMERO]

		        WHERE
                    T.[NUMERO] = @NUMERO";

        #endregion
        public ValidationResult Inserir(Teste teste)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(teste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            SqlCommand comandoInsercaoTesteQuestao =
                new SqlCommand(sqlInserirTesteQuestao, conexaoComBanco);

            ConfigurarParametrosTeste(teste, comandoInsercao);

            conexaoComBanco.Open();
            var _id = comandoInsercao.ExecuteScalar();
            int id = Convert.ToInt32(_id);
            teste.Id = id;
            foreach (var questao in teste.questoes)
            {
                ConfigurarParametrosTeste_Questao
                    (id, questao.Id, comandoInsercaoTesteQuestao);
                comandoInsercaoTesteQuestao.ExecuteScalar();
                comandoInsercaoTesteQuestao.Parameters.Clear();
            }
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Editar(Teste teste)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(teste);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            SqlCommand comandoExcluirTesteQuestao = new SqlCommand(sqlExcluirTesteQuestao, conexaoComBanco);
            SqlCommand comandoInserirTesteQuestao = new SqlCommand(sqlInserirTesteQuestao, conexaoComBanco);

            conexaoComBanco.Open();

            comandoExcluirTesteQuestao.Parameters.AddWithValue("NUMERO_QUESTAO", teste.Id);
            comandoExcluirTesteQuestao.ExecuteNonQuery();

            ConfigurarParametrosTeste(teste, comandoEdicao);

            int id = teste.Id;
            foreach(var questao in teste.questoes)
            {                
                ConfigurarParametrosTeste_Questao
                    (id, questao.Id,comandoInserirTesteQuestao);
                comandoInserirTesteQuestao.ExecuteNonQuery();
                comandoInserirTesteQuestao.Parameters.Clear();
            }
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Excluir(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            SqlCommand comandoExclusaoTesteQuestao = new SqlCommand(sqlExcluirTesteQuestao, conexaoComBanco);

            comandoExclusaoTesteQuestao.Parameters.AddWithValue("NUMERO_TESTE", teste.Id);
            
            comandoExclusao.Parameters.AddWithValue("NUMERO", teste.Id);

            conexaoComBanco.Open();
            comandoExclusaoTesteQuestao.ExecuteNonQuery();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public List<Teste> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            List<Teste> testes = new List<Teste>();

            while (leitorTeste.Read())
            {
                Teste teste = ConverterParaTeste(leitorTeste);

                testes.Add(teste);
            }

            conexaoComBanco.Close();

            return testes;
        }
        public Teste SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            Teste teste = null;
            if (leitorTeste.Read())
                teste = ConverterParaTeste(leitorTeste);

            conexaoComBanco.Close();

            return teste;
        }
        private static Teste ConverterParaTeste(SqlDataReader leitorTeste)
        {
            int numero = Convert.ToInt32(leitorTeste["NUMERO"]);
            string titulo = Convert.ToString(leitorTeste["TITULO"]);

            int numeroDisciplina = Convert.ToInt32(leitorTeste["DISCIPLINA_NUMERO"]);
            string nomeDisciplina = Convert.ToString(leitorTeste["DISCIPLINA_TITULO"]);

            int numeroMateria = Convert.ToInt32(leitorTeste["MATERIA_NUMERO"]);
            string nomeMateria = Convert.ToString(leitorTeste["MATERIA_TITULO"]);
            int serieMateria = Convert.ToInt32(leitorTeste["MATERIA_SERIE"]);

            var teste = new Teste
            {
                Id = numero,
                Nome = titulo,
                Disciplina = new Disciplina
                {
                    Id = numeroDisciplina,
                    Nome = nomeDisciplina
                },
                Materia = new Materia
                {
                    Id = numeroMateria,
                    Nome = nomeMateria,
                    Serie = (SerieEnum)serieMateria
                },

                questoes = new List<Questao>()
            };

            return teste;
        }
        private static void ConfigurarParametrosTeste
            (Teste teste, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("NUMERO", teste.Id);
            comandoInsercao.Parameters.AddWithValue("TITULO", teste.Nome);
            comandoInsercao.Parameters.AddWithValue("DISCIPLINA_NUMERO", teste.Disciplina.Id);
            comandoInsercao.Parameters.AddWithValue("MATERIA_NUMERO", teste.Materia.Id);
            comandoInsercao.Parameters.AddWithValue("DATA", teste.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("PROVAO", teste.Provao);

        }
        private static void ConfigurarParametrosTeste_Questao
            (int teste, int questao, SqlCommand comandoInsercao)
        {
            comandoInsercao.Parameters.AddWithValue("NUMERO_QUESTAO", teste);
            comandoInsercao.Parameters.AddWithValue("NUMERO_QUESTAO", questao);
        }
    }
}

