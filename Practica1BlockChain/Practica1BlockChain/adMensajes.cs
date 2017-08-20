using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1Estructuras
{
    public partial class adMensajes : Form
    {
        Form1 f;
        
        public adMensajes()
        {
            InitializeComponent();
          
        }

        private void adMensajes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            f = new Practica1Estructuras.Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //para enviar mensajes
            this.Hide();
            EnviarMensajes en = new EnviarMensajes();
            en.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cola c = new Practica1Estructuras.cola();
            c.Show();
        }
    }
}
