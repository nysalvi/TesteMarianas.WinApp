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

namespace TesteMariana.WinApp.ModuloMateria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        private Materia materia;
        public TelaCadastroMateriaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();
            CarregarDisciplinas(disciplinas);
        }

        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            comboBoxDisciplina.Items.Clear();

            foreach (var item in disciplinas)
            {
                comboBoxDisciplina.Items.Add(item);
            }
        }


        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        public Materia Materia
        {
            get { return materia; }
            set
            {
                materia = value;


                if (materia.Serie == SerieEnum.Primeira)
                {
                    radioButtonSerieUm.Checked = true;
                }
                else
                {
                    radioButtonSerieDois.Checked = true;
                }
                comboBoxDisciplina.SelectedItem = materia.disciplina;
                textBoxNome.Text = materia.Nome;

            }
        }

        private void TelaCadastroCompromissosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCompromisssosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.Nome = textBoxNome.Text;
            materia.disciplina = (Disciplina)comboBoxDisciplina.SelectedItem;
            
            if (radioButtonSerieUm.Checked)
            {
                materia.Serie = SerieEnum.Primeira;
            }
            else
            {
                materia.Serie = SerieEnum.Segunda;
            }

            var resultadoValidacao = GravarRegistro(materia);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
