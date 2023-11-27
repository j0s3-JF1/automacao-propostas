using System;
using System.Windows.Forms;
using ELO_LOCACAO.Loading;
using ELO_LOCACAO.Paginas;
using ELO_LOCACAO.PopUp;

namespace ELO_LOCACAO
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLoading());
        }
    }
}
