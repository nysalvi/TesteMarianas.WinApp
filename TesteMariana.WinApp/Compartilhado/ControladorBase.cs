using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteMariana.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {

        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();

        public virtual void Duplicar()
        {

        }
        public virtual void PDF()
        {

        }


        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObtemConfiguracaoToolbox();



    }
}
