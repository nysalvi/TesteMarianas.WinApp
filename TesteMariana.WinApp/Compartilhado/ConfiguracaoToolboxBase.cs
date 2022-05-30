﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteMariana.WinApp.Compartilhado
{
    public abstract class ConfiguracaoToolboxBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }
        public abstract string TooltipGerarPdf { get; }

        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool TooltipGerarpdfHabilitado { get { return true; } }
    }
}
