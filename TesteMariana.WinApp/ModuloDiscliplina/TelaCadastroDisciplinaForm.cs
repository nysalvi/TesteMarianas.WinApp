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

namespace TesteMariana.WinApp.ModuloDiscliplina
{


    public partial class TelaCadastroDisciplinaForm : Form
    {
        private Disciplina disciplina;
        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();

        }


        public Func<Disciplina, ValidationResult> GravarRegistro { get; set; }

        public Disciplina Disciplina
        {
            get { return disciplina; }
            set
            {
                disciplina = value;

                txtBoxDisciplina.Text = disciplina.Nome;
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
            disciplina.Nome = txtBoxDisciplina.Text;

            var resultadoValidacao = GravarRegistro(disciplina);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
