using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace exercicioLp2
{
    static class Program
    {
        public static MessageBoxButtons MessageBoxButtons { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new inicioEleicao());
            Application.Run(new deputadoFederal());
            Application.Run(new DeputadoEstadual());
            Application.Run(new Senador());
            Application.Run(new Governador());
            Application.Run(new Presidente());
            DialogResult continuar = MessageBox.Show("Deseja continuar votando?", "Escolha uma opção", MessageBoxButtons.YesNo);
            while (continuar == DialogResult.Yes)
            {
                Application.Run(new deputadoFederal());
                Application.Run(new DeputadoEstadual());
                Application.Run(new Senador());
                Application.Run(new Governador());
                Application.Run(new Presidente());
                ResultadoEleicao resultado = new ResultadoEleicao();
                
                continuar = MessageBox.Show("Deseja continuar votando?", "Escolha uma opção", MessageBoxButtons.YesNo);
            }
            
            
            

        }
    }
}
