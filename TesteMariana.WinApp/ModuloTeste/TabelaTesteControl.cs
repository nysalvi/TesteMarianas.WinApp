using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloTeste;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {
        public TabelaTesteControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado", HeaderText = "Enunciado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NumeroQuestoes", HeaderText = "NumeroQuestoes"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataCriacao", HeaderText = "DataCriacao"},               

               
            };

            return colunas;
        }
        public int ObtemNumeroTesteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
        public void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (var teste in testes)
            {
                grid.Rows.Add(teste.Id, teste.Titulo, teste.Materia.Nome, teste.Disciplina.Nome,
                    teste.NumeroQuestoes, teste.DataCriacao.ToShortDateString());
            }
        }
    }
}
