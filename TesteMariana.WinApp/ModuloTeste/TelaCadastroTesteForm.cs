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
using TesteMariana.Dominio.ModuloTeste;

namespace TesteMariana.WinApp.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        private Teste teste;
        private List<Materia> materias;
        private List<Questao> questoes;
        public TelaCadastroTesteForm(List<Disciplina> disciplinas, List<Materia> materias, List<Questao> questoes)
        {
            InitializeComponent();
            this.materias = materias;
            this.questoes = questoes;


            CarregarDisciplinas(disciplinas);

            CarregarMaterias(materias);



        }
        public Func<Teste, ValidationResult> GravarRegistro { get; set; }

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

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            comboBoxDisciplina.Items.Clear();

            foreach (var item in disciplinas)
            {
                comboBoxDisciplina.Items.Add(item);
            }
        }

        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;
                txtBoxTitulo.Text = teste.Nome;
                comboBoxDisciplina.SelectedItem = teste.Disciplina;
                comboBoxMateria.SelectedItem = teste.Materia;
                dateTimePicker.Text = teste.DataCriacao.ToShortDateString();
                textBoxQuantidadeQuestoes.Text = teste.NumeroQuestoes.ToString();

                foreach (Questao item in teste.questoes)
                {
                    listBoxQuestoes.Items.Add(item);
                }


                if (teste.Provao == true)
                    checkBoxProvaRecuperacao.Checked = true;
                else
                    checkBoxProvaRecuperacao.Checked = false;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
                       
                teste.Nome = txtBoxTitulo.Text;
                teste.DataCriacao = dateTimePicker.Value;

                if (checkBoxProvaRecuperacao.Checked)
                    teste.Provao = true;
                else
                    teste.Provao = false;


                var resultadoValidacao = GravarRegistro(teste);

                if (resultadoValidacao.IsValid == false)
                {
                    string erro = resultadoValidacao.Errors[0].ErrorMessage;

                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            
        }

        private void bntSortearQuestao_Click(object sender, EventArgs e)
        {
            List<Questao> Questoes = new();
            if (checkBoxProvaRecuperacao.Checked == true)
                Questoes = CarregarQuestoesProvao();
            else
                Questoes = CarregarQuestoesMateria();

            listBoxQuestoes.Items.Clear();

            foreach (Questao item in Questoes)
            {
                listBoxQuestoes.Items.Add(item);
            }
        }

        private List<Questao> CarregarQuestoesProvao()
        {
            List<Questao> Questoes = new();
            int numeroDeQuestoes = Convert.ToInt32(textBoxQuantidadeQuestoes.Text);
            Disciplina disciplinaSelecionada = (Disciplina)comboBoxDisciplina.SelectedItem;
            List<Questao> sortearQuestão = new();

            Random rnd = new Random();

            for (int i = 0; i < numeroDeQuestoes; i++)
            {
                Materia materiaselecionada = materias[rnd.Next(materias.Count)];

                foreach (Questao item in questoes)
                {
                    if (item.materia == materiaselecionada)
                        sortearQuestão.Add(item);
                }

                Random random = new Random();

                Questao questaoAleatoria = sortearQuestão[random.Next(sortearQuestão.Count)];

                if (Questoes.Contains(questaoAleatoria))
                {
                    i--;
                }
                else
                {
                    Questoes.Add(questaoAleatoria);
                }
            }

            return Questoes;
        }

        private List<Questao> CarregarQuestoesMateria()
        {

            int numeroDeQuestoes = Convert.ToInt32(textBoxQuantidadeQuestoes.Text);
            Materia materiaselecionada = (Materia)comboBoxMateria.SelectedItem;
            List<Questao> Questoes = new();
            List<Questao> sortearQuestão = new();

            foreach (Questao item in questoes)
            {
                if (item.materia == materiaselecionada)
                    sortearQuestão.Add(item);
            }
            for (int i = 0; i < numeroDeQuestoes; i++)
            {

                Random rnd = new Random();

                Questao questaoAleatoria = sortearQuestão[rnd.Next(sortearQuestão.Count)];

                if (Questoes.Contains(questaoAleatoria))
                {
                    i--;
                }
                else
                {
                    Questoes.Add(questaoAleatoria);
                }


            }
            return Questoes;
        }

        private void comboBoxDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxMateria.Enabled = true;
            CarregarMaterias(materias);
        }
    }
}
