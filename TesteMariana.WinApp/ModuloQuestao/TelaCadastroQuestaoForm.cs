using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Dominio.ModuloQuestao;

namespace TesteMariana.WinApp.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private List<Materia> materias;
        private List<Alternativas> alternativas;
        private IRepositorioQuestao repositorioQuestao;
        private char letra = 'a';
        public TelaCadastroQuestaoForm(List<Disciplina> disciplinas, List<Materia> materias, IRepositorioQuestao repositorioQuestao)
        {
            InitializeComponent();
            this.repositorioQuestao = repositorioQuestao;
            CarregarDisciplinas(disciplinas);
            this.materias = materias;
            CarregarMaterias(materias);
            alternativas = new();

        }

        private Questao questao;

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            comboBoxDisciplina.Items.Clear();

            foreach (var item in disciplinas)
            {
                comboBoxDisciplina.Items.Add(item);
            }
        }
        /*
        private void CarregarMaterias(List<Materia> materias)
        {

            comboBoxMateria.Items.Clear();

            foreach (var item in materias)
            {
                if (item.disciplina == (Disciplina)comboBoxDisciplina.SelectedItem)
                {
                    comboBoxMateria.Items.Add(item);
                }

            }
        }
        */
        private void CarregarMaterias(List<Materia> materias)
        {

            comboBoxMateria.Items.Clear();

            foreach (var item in materias)
            {
                comboBoxMateria.Items.Add(item);
            }
        }

        public Questao Questao
        {
            get { return questao; }
            set
            {
                questao = value;

                txtBoxEnunciado.Text = questao.Nome;
                comboBoxDisciplina.SelectedItem = questao.disciplina;
                comboBoxMateria.SelectedItem = questao.materia;

                foreach (Alternativas item in questao.alternativas)
                {
                    listBoxRespostas.Items.Add(item);
                }

            }
        }
        public List<Alternativas> AlternativasAdicionadas
        {
            get
            {
                return listBoxRespostas.Items.Cast<Alternativas>().ToList();
            }
        }

        private void btnAdicionarResposta_Click(object sender, EventArgs e)
        {
            
            List<string> titulos = AlternativasAdicionadas.Select(x => x.Resposta).ToList();

            if (titulos.Count == 0 || titulos.Contains(txtBoxResposta.Text) == false)
            {
                Alternativas alternativa = new();

                alternativa.Resposta = txtBoxResposta.Text;
                alternativa.letra = letra;
                alternativa.Correta = checkBoxAlternativaCorreta.Checked;

                alternativas.Add(alternativa);

                listBoxRespostas.Items.Add(alternativa);

                if (letra == 'z')
                    letra = 'A';
                else
                    letra++;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Nome = txtBoxEnunciado.Text;
            questao.disciplina = (Disciplina)comboBoxDisciplina.SelectedItem;
            questao.materia = (Materia)comboBoxMateria.SelectedItem;
            foreach (Alternativas item in alternativas)
            {
                questao.alternativas.Add(item);
            }
            var resultadoValidacao = GravarRegistro(Questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void comboBoxDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxMateria.Enabled = true;
            CarregarMaterias(materias);
        }
    }
}
