using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.WinApp.Compartilhado;

namespace TesteMariana.WinApp.ModuloTeste
{
    public class ConfiguracaoToolboxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Testes";

        public override string TooltipInserir => "Inserir um novo teste";

        public override string TooltipEditar => "Editar um teste existente";

        public override string TooltipExcluir => "Excluir um teste existente";

        public override string TooltipGerarPdf => "Gerar um PDF";
    }

}

