using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1Estructuras
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("ya va abrir el form1");
            try
            {
                Application.Run(new Form1());
                Console.WriteLine("ya abrio el form");
            }
            catch (Exception)
            {
                Console.WriteLine("no abrio el form");
                throw;
            }
            
           
        }
    }
}
