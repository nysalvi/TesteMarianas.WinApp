using FluentValidation.Results;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.Compartilhado;

namespace TesteMariana.Infra.BancoDados.ModuloMateria
{
    public class RepositorioMateriaEmBancoDados : IRepositorioMateria
    {

        private const string enderecoBanco =
                 "Data Source=(LocalDB)\\MSSqlLocalDB;" +
                     "Initial Catalog=MarianaDb;" +
                 "Integrated Security=True;" +
                 "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
        @"INSERT INTO [TBMateria]
           (
            [TITULO]
           ,[SERIE]
           ,[DISCIPLINA_NUMERO])
        VALUES
           (@TITULO
           ,@SERIE
           ,@DISCIPLINA_NUMERO);
            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
           @"UPDATE [TBMateria]	
		        SET
			        [TITULO] = @TITULO,
			        [SERIE] = @SERIE,
                    [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO

		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBMateria]
		        WHERE
			        [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
           @"SELECT 
                MT.NUMERO,
                MT.TITULO,
                MT.SERIE,
                MT.DISCIPLINA_NUMERO,
                    
                D.NUMERO AS DISCIPLINA_NUMERO,
		        D.TITULO AS DISCIPLINA_TITULO

            FROM 
                TBMateria AS MT INNER JOIN 
                TBDisciplina AS D ON
                MT.DISCIPLINA_NUMERO = D.NUMERO";


        private const string sqlSelecionarPorNumero =
           @"SELECT 
		        M.[NUMERO], 
		        M.[TITULO],
                M.[SERIE],
                M.[DISCIPLINA_NUMERO],

				D.[TITULO] as DISCIPLINA_TITULO
                    
            FROM 
		            TBMateria as M inner join 
                    TBDisciplina as D on 
                    M.Disciplina_Numero = D.NUMERO
		        WHERE
                    M.[NUMERO] = @NUMERO";


        #endregion
        public ValidationResult Inserir(Materia materia)
        {


            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosMateria(materia, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            materia.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return new ValidationResult();
        }
        public ValidationResult Editar(Materia materia)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(materia);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosMateria(materia, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public ValidationResult Excluir(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", materia.Id);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);

                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }
        public Materia SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia materia = null;
            if (leitorMateria.Read())
                materia = ConverterParaMateria(leitorMateria);

            conexaoComBanco.Close();

            return materia;
        }
        private static Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            int numero = Convert.ToInt32(leitorMateria["NUMERO"]);
            string titulo = Convert.ToString(leitorMateria["TITULO"]);
            int serie = Convert.ToInt32(leitorMateria["SERIE"]);

            int numeroDisciplina = Convert.ToInt32(leitorMateria["DISCIPLINA_NUMERO"]);
            string nomeDisciplina = Convert.ToString(leitorMateria["DISCIPLINA_TITULO"]);

            var materia = new Materia
            {
                Id = numero,
                Nome = titulo,
                Serie = (SerieEnum)serie,
                disciplina = new Disciplina
                {
                    Id = numeroDisciplina,
                    Nome = nomeDisciplina
                }

            };

            return materia;
        }
        private static void ConfigurarParametrosMateria(Materia materia, SqlCommand comandoInsercao)
        {


            comandoInsercao.Parameters.AddWithValue("NUMERO", materia.Id);
            comandoInsercao.Parameters.AddWithValue("TITULO", materia.Nome);
            comandoInsercao.Parameters.AddWithValue("SERIE", materia.Serie);
            comandoInsercao.Parameters.AddWithValue("DISCIPLINA_NUMERO", materia.disciplina.Id);

        }

    }
}
