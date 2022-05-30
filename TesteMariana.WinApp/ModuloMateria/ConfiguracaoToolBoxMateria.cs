using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloMateria
{
    internal class ConfiguracaoToolBoxMateria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Materias";

        public override string TooltipInserir => "Inserir uma nova materia";

        public override string TooltipEditar => "Editar uma materia existente";

        public override string TooltipExcluir => "Excluir uma materia existente";

        public override string TooltipGerarPdf => "Gerar um PDF";

    }
}
