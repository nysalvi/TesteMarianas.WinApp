using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Dominio.ModuloQuestao;
using TesteMariana.Dominio.ModuloTeste;
using TesteMariana.Infra.Arquivos.Compartilhado.Serializadores;

namespace TesteMariana.Infra.Arquivos.Compartilhado
{
    [Serializable]
    public class DataContext
    {
        private readonly ISerializador serializador;

        public DataContext()
        {
            Testes = new List<Teste>();

            Questoes = new List<Questao>();

            Disciplinas = new List<Disciplina>();

            Materias = new List<Materia>();
        }

        public DataContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Teste> Testes { get; set; }

        public List<Questao> Questoes { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

        public List<Materia> Materias { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Testes.Any())
                this.Testes.AddRange(ctx.Testes);

            if (ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);

            if (ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);
        }
    }
}
