using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TesteMariana.Infra.Arquivos.Compartilhado;
using TesteMariana.WinApp.Compartilhado;
using TesteMariana.WinApp.ModuloQuestao;
using TesteMariana.WinApp.ModuloTeste;
using TesteMariana.WinApp.ModuloMateria;
using TesteMariana.WinApp.ModuloDiscliplina;
using TesteMariana.Infra.BancoDados.ModuloDisciplina;
using TesteMariana.Infra.BancoDados.ModuloMateria;
using TesteMariana.Infra.BancoDados.ModuloTeste;

namespace TesteMariana.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        //private DataContext contextoDados;

        public TelaPrincipalForm(DataContext contextoDados)
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            //this.contextoDados = contextoDados;

            InicializarControladores();

        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void testeMenuItem_Click(object sender, EventArgs e)   // botoes do menu de categorias
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void disciplinaMenuItem_Click(object sender, EventArgs e)// botoes do menu de categorias
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void materiaMenuItem_Click(object sender, EventArgs e)// botoes do menu de categorias
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void questoesMenuItem_Click(object sender, EventArgs e)// botoes do menu de categorias
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void toolStripBtnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void toolStripBntEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void toolStripBntExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void toolStripBntPdf_Click(object sender, EventArgs e)
        {
            controlador.PDF();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            toolStripBtnInserir.Enabled = configuracao.InserirHabilitado;
            toolStripBntEditar.Enabled = configuracao.EditarHabilitado;
            toolStripBntExcluir.Enabled = configuracao.ExcluirHabilitado;
            toolStripBntPdf.Enabled = configuracao.TooltipGerarpdfHabilitado;  // botao adicionar PDF

        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            toolStripBtnInserir.ToolTipText = configuracao.TooltipInserir;
            toolStripBntEditar.ToolTipText = configuracao.TooltipEditar;
            toolStripBntExcluir.ToolTipText = configuracao.TooltipExcluir;
           toolStripBntPdf.ToolTipText = configuracao.TooltipGerarPdf;  // botao adicionar PDF
        
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox1.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {

            var repositorioTeste = new RepositorioTesteEmBancoDados();
            var repositorioQuestao = new RepositorioQuestaoEmBancoDados();
            var repositorioMateria = new RepositorioMateriaEmBancoDados();

            var repositorioDisciplina = new RepositorioDisciplinaEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Teste", new ControladorTeste(repositorioTeste,repositorioQuestao, repositorioMateria,repositorioDisciplina));
            controladores.Add("Questões", new ControladorQuestao(repositorioQuestao, repositorioMateria, repositorioDisciplina));
            controladores.Add("Materia", new ControladorMateria(repositorioMateria, repositorioDisciplina));
            controladores.Add("Disciplina", new ControladorDisciplina(repositorioDisciplina));

        }

      
    }
}
