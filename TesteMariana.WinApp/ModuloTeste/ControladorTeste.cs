using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Dominio.ModuloQuestao;
using TesteMariana.Dominio.ModuloTeste;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private readonly IRepositorioQuestao repositorioQuestao;
        private readonly IRepositorioTeste repositorioTeste;

        private TabelaTesteControl tabelaTeste;

        public ControladorTeste(IRepositorioTeste repositorioTeste, IRepositorioQuestao repositorioQuestao,
            IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina )
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioTeste = repositorioTeste;
        }

        public override void Inserir()
        {

            var disciplina = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            if (disciplina.Count == 0)
            {
                MessageBox.Show("Crie uma disciplina primeiro",
               "Criação de Teste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (materias.Count == 0)
            {
                MessageBox.Show("Crie uma materia primeiro",
               "Criação de Teste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (questoes.Count == 0)
            {
                MessageBox.Show("Crie uma questão primeiro",
               "Criação de Teste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplina, materias, questoes);
            tela.Teste = new Teste();

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Editar()
        {

            Teste TesteSelecionado = ObtemTesteSelecionado();

            if (TesteSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Edição de Teste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var materia = repositorioMateria.SelecionarTodos();
            var disciplina = repositorioDisciplina.SelecionarTodos();
            var questão = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplina, materia, questão);

            tela.Teste = TesteSelecionado;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Excluir()
        {
            Teste TesteSelecionado = ObtemTesteSelecionado();

            if (TesteSelecionado == null)
            {
                MessageBox.Show("Selecione uma Teste primeiro",
                "Exclusão de teste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o teste?",
                "Exclusão de teste", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(TesteSelecionado);
                CarregarTestes();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTeste == null)
                tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTeste();
        }


        private Teste ObtemTesteSelecionado()
        {

            var numero = tabelaTeste.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }

        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {testes.Count} Teste(s)");
        }

        public Func<Teste, ValidationResult> GravarRegistro { get; set; }

        public override void Duplicar()
        {
            Teste TesteSelecionado = ObtemTesteSelecionado();

            Teste teste = (Teste)TesteSelecionado.Clone();

            GravarRegistro = repositorioTeste.Inserir;

            GravarRegistro(teste);

            CarregarTestes();
        }

        public override void PDF()
        {
            throw new NotImplementedException();
        }

    }
}
