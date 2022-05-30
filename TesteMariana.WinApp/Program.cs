using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteMariana.Infra.Arquivos.Compartilhado;
using TesteMariana.Infra.Arquivos.Compartilhado.Serializadores;

namespace TesteMariana.WinApp
{
    internal static class Program
    {
        static ISerializador serializador = new SerializadorDadosEmJsonDotnet();

        static DataContext contexto = new DataContext(serializador);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm(contexto));

            contexto.GravarDados();

        }

    }
}
