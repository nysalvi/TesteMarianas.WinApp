using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Dominio.ModuloQuestao;
using TesteMariana.WinApp.Compartilhado;
using static TesteMariana.WinApp.ModuloQuestao.ConfiguracaoToolboxQuestao;

namespace TesteMariana.WinApp.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioQuestao repositorioQuestao;


        private TabelaQuestaoControl tabelaQuestao;
        public ControladorQuestao(IRepositorioQuestao repositorioQuestao, 
            IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina )
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioQuestao = repositorioQuestao;
        }

        public override void Inserir()
        {
            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();

            if (disciplinas.Count == 0)
            {
                MessageBox.Show("Crie uma disciplina primeiro",
                   "Criação de Questão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (materias.Count == 0)
            {
                MessageBox.Show("Crie uma materia primeiro",
               "Criação de Questão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroQuestaoForm tela = new TelaCadastroQuestaoForm(disciplinas, materias, repositorioQuestao);
            tela.Questao = new Questao();
            tela.Questao.disciplina = new Disciplina();
            tela.Questao.materia = new Materia();
            tela.Questao.alternativas = new List<Alternativas>();

            tela.GravarRegistro = repositorioQuestao.Inserir;

            DialogResult resultado = tela.ShowDialog();


            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }

            
        }

        public override void Editar()
        {
            Questao QuestaoSelecionada = ObtemQuestaoSelecionada();

            if (QuestaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro",
                "Edição de Questão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var disciplina = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();

            TelaCadastroQuestaoForm tela = new TelaCadastroQuestaoForm(disciplina, materias, repositorioQuestao);

            tela.Questao = QuestaoSelecionada;

            tela.GravarRegistro = repositorioQuestao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarQuestoes();
            }


        }

        public override void Excluir()
        {
            Questao questaoSelecionada = ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Questão primeiro",
                "Exclusão de questão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a questão?",
                "Exclusão de questão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);
                CarregarQuestoes();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new TabelaQuestaoControl();

            CarregarQuestoes();

            return tabelaQuestao;
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxQuestao();
        }

        private Questao ObtemQuestaoSelecionada()
        {
            var numero = tabelaQuestao.ObtemNumeroQuestaoSelecionado();

            return repositorioQuestao.SelecionarPorNumero(numero);
        }

        private void CarregarQuestoes()
        {
            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {questoes.Count} Questõe(s)");
        }


        public override void PDF()
        {
            throw new NotImplementedException();
        }

    }
}
