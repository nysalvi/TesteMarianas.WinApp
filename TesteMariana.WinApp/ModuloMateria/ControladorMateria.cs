using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.WinApp.Compartilhado;
using TesteMariana.WinApp.ModuloDiscliplina;

namespace TesteMariana.WinApp.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioDisciplina repositorioDisciplina;

        private TabelaMateriaControl tabelaMateria;

        public ControladorMateria(IRepositorioMateria repositorioMateria, IRepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Inserir()
        {
            var disciplina = repositorioDisciplina.SelecionarTodos();

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(disciplina);
            tela.Materia = new Materia();

            tela.GravarRegistro = repositorioMateria.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMateria();
            }
        }

        public override void Editar()
        {
            Materia materiaSelecionado = ObtemMateriaSelecionado();

            if (materiaSelecionado == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Edição de Materias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var disciplina = repositorioDisciplina.SelecionarTodos();

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(disciplina);

            tela.Materia = materiaSelecionado;

            tela.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarMateria();
            }
        }

        public override void Excluir()
        {
            Materia materiaSelecionado = ObtemMateriaSelecionado();

            if (materiaSelecionado == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Exclusão de matéria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a matéria?",
                "Exclusão de Matéria", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionado);
                CarregarMateria();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaMateria == null)
                tabelaMateria = new TabelaMateriaControl();

            CarregarMateria();

            return tabelaMateria;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxMateria();
        }

        private Materia ObtemMateriaSelecionado()
        {
            var numero = tabelaMateria.ObtemNumeroMateriaSelecionado();

            return repositorioMateria.SelecionarPorNumero(numero);
        }

        private void CarregarMateria()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMateria.AtualizarRegistros(materias);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {materias.Count} materias(s)");
        }


        public override void PDF()
        {
            //throw new NotImplementedException();
        }


    }
}
