using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1Estructuras
{
    public partial class EnviarMensajes : Form
    {
        private static readonly HttpClient client = new HttpClient();
        adMensajes a;
        public EnviarMensajes()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (txtOP.Text.Length > 0 && txtIP.Text.Length > 0)
            {
                try
                {
                    string ip = txtIP.Text;
                    string op = txtOP.Text;
                    //var responseString = await client.GetStringAsync("http://127.0.0.1:5000/hola");
                    var datos = new Dictionary<string, string>
                    {
                     {"inorden",op },
                    };
                        var contenido = new FormUrlEncodedContent(datos);
                        var response = await client.PostAsync("http://" + ip + ":5000/mensaje", contenido);
                        var respuesta = await response.Content.ReadAsStringAsync();
                    if (respuesta.Equals("true"))
                    {
                        MessageBox.Show("Respuesta recibida: " + respuesta);
                    }else
                    {
                        MessageBox.Show("Ocurrio un error al Enviar el mensaje");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ocurrio un error al enviar el mensaje");
                    throw;
                }

            }
            else
            {
                MessageBox.Show("No ha Ingresado ninguna Información", "My Application",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
             
            }

        }

        private void EnviarMensajes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            a = new adMensajes();
            a.Show();
        }

        private void EnviarMensajes_Load(object sender, EventArgs e)
        {

        }
    }
 }

