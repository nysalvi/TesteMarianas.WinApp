using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloMateria
{
    public partial class TabelaMateriaControl : UserControl
    {
        public TabelaMateriaControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Numero"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},                

                 new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                 new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Serie"},
            };

            return colunas;
        }

        public int ObtemNumeroMateriaSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach (var materia in materias)
            {
                grid.Rows.Add(materia.Id, materia.Nome, materia.disciplina.Nome, materia.Serie);
            }
        }

    }
}
