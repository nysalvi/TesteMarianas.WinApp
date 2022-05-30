using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloQuestao
{
    public class ConfiguracaoToolboxQuestao
    {
        internal class ConfiguracaoToolBoxQuestao : ConfiguracaoToolboxBase
        {
            public override string TipoCadastro => "Controle de Questões";

            public override string TooltipInserir => "Inserir uma nova questão";

            public override string TooltipEditar => "Editar uma questão existente";

            public override string TooltipExcluir => "Excluir uma questão existente";

            public override string TooltipGerarPdf => "Gerar um PDF";

        }
    }
}
