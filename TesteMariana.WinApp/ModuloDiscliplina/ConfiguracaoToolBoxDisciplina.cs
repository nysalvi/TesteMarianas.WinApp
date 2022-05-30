using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloDiscliplina
{
    public class ConfiguracaoToolBoxDisciplina : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Disciplinas";

        public override string TooltipInserir => "Inserir uma nova disciplina";

        public override string TooltipEditar => "Editar uma disciplina existente";

        public override string TooltipExcluir => "Excluir uma disciplina existente";

        public override string TooltipGerarPdf => "Gerar um PDF";


    }
}
