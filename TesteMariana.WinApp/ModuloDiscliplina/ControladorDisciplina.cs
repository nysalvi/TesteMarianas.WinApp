using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloDiscliplina
{
    public class ControladorDisciplina : ControladorBase
    {
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private TabelaDisciplinaControl tabelaDisciplina;

        public ControladorDisciplina(IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir() 
        {
            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();
            tela.Disciplina = new Disciplina();

            tela.GravarRegistro = repositorioDisciplina.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplina();
            }
        }

        public override void Editar()
        {
            Disciplina tarefaSelecionada = ObtemDisciplinaSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();

            tela.Disciplina = tarefaSelecionada;

            tela.GravarRegistro = repositorioDisciplina.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplina();
            }
        }

        public override void Excluir()
        {
            Disciplina tarefaSelecionada = ObtemDisciplinaSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma Disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Disciplina?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(tarefaSelecionada);
                CarregarDisciplina();
            }
        }

        public override UserControl ObtemListagem() // mostrar lista tela 
        {
            if (tabelaDisciplina == null)
                tabelaDisciplina = new TabelaDisciplinaControl();

            CarregarDisciplina();

            return tabelaDisciplina;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxDisciplina();
        }


        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = tabelaDisciplina.ObtemNumeroDisciplinaSelecionada();

            return repositorioDisciplina.SelecionarPorNumero(numero);
        }


        private void CarregarDisciplina()
        {
            
            List<Disciplina> disciplinas = repositorioDisciplina.SelecionarTodos();

            tabelaDisciplina.AtualizarRegistros(disciplinas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {disciplinas.Count} disciplinas(s)");
        }


        public override void PDF()
        {
            throw new NotImplementedException();
        }


    }
}
