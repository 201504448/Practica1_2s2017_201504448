using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Xml;

namespace Practica1Estructuras
{
    public partial class Form1 : Form
    {
        public static Form1 f;
        RootObject jd;
        public static string texto = "";
        public static string ipLocal = "";
        public static string mascara = "";
        public static string carnet = "";
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            vaciar();
        }

        private void recargar()
        {
            string estado = "";
            int fila = 0;
            int num = 1;
            foreach (Nodo n in jd.nodos.nodo)
            {
                carnet = verCarnet(n.ip);
                try
                {
                    if (!carnet.Equals("no"))
                    {
                        estado = "Conectado";
                    }
                    else
                    {
                        estado = "Desconectado";
                    }
                    cargarJson(n.ip, n.mascara, carnet, estado);
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[fila].Cells[0].Value = "Nodo" + num;
                    dataGridView1.Rows[fila].Cells[1].Value = n.ip;
                    dataGridView1.Rows[fila].Cells[2].Value = carnet;
                    dataGridView1.Rows[fila].Cells[3].Value = estado;
                    fila++;
                    num++;
                }
                catch (Exception)
                {
                    MessageBox.Show("ocurrio un error al insertar el nodo");
                }

            }
        }

        private string verCarnet(String ip)
        {
            string respuesta = "";
            try
            {

                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString("http://" + ip + ":5000/conectado");
                    respuesta = responseString;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo consultar el carnet");
                respuesta = "no";//no hubo respuesta pues
            }


            return respuesta;

        }

        public void cargarJson(String ip, String mascara, String carnet, String estado)
        {
            using (var client = new WebClient())
            {

                var values = new NameValueCollection();
                values["ip"] = "\"" + ip + "\"";
                values["mascara"] = "\"" + mascara + "\"";
                values["carnet"] = "\"" + carnet + "\"";
                values["estado"] = "\"" + estado + "\"";

                //pero como ya tenemos el carnet deberiamos de una al momento de hacer el json hacer una consulta al otro nodo
                //y si nos devuelve el carnet esta conectado si no esta desconectado

                var response = client.UploadValues("http://localhost:5000/cargajson", values);
                var responseString = Encoding.Default.GetString(response);
                MessageBox.Show(responseString);
                //de una vez deberiamos ir llenando el datagridview pienso yo 
            }
        }

        private async void vaciar()
        {
            try
            {
                {
                    var request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/vaciarListaSimple");

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    Console.WriteLine(responseString);
                }
                //    
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo vaciar la lista");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            texto = "";
            try
            {
                //Abrir JSON

                // Mostrar OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON|*.json";
                openFileDialog.Title = "Seleccione una archivo JSON";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    texto = sr.ReadToEnd();
                    sr.Close();
                    string carnet = "";
                    Console.WriteLine(texto);
                    jd = JsonConvert.DeserializeObject<RootObject>(texto);
                    ipLocal = jd.nodos.local;
                    mascara = jd.nodos.mascara;
                    textBox1.Text = "  " + ipLocal + " - 201504448";
                    //Mostrar en consola la ip
                    Console.WriteLine(ipLocal);
                    //consultarCarnet("http://localhost:5000/conectado");
                    cargarJson(ipLocal, mascara, "201504448", "Conectado");
                    recargar();



                    try
                    {//vamos a ver la lista 

                        using (var client = new WebClient())
                        {
                            var responseString = client.DownloadString("http://localhost:5000/listaNodos");
                            MessageBox.Show(responseString);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ocurrio un error al querer ver la lista de nodos");
                    }

                }



                this.Show();

            }
            catch (Exception)
            {
                this.Show();
                throw;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private static readonly HttpClient cliente = new HttpClient();

        private async void button9_Click(object sender, EventArgs e)
        {
            if (txtOP.Text.Length > 0 && txtIP.Text.Length > 0)
            {
                post_enviarMsj(txtIP.Text, txtOP.Text);

            }
            else
            {
                MessageBox.Show("No ha Ingresado ninguna Información", "My Application",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML|*.xml";
                openFileDialog.Title = "Seleccione una archivo XML";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    texto = sr.ReadToEnd();
                    Console.WriteLine(texto);
                    //mandamos abrir la ruta del archivo
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(texto);

                        string json = JsonConvert.SerializeXmlNode(doc);
                        //json = json.Replace("\\n", "");
                        //json = json.Replace("\\t", "");
                        //json = json.Replace("\\r", "");

                        Console.WriteLine(json);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ocurrio un error al querer transformar el xml");
                        throw;

                    }

                }
                this.Show();
            }
            catch (Exception)
            {
                this.Show();
                throw;
            }

        }

        public void enviarMensaje(String json)
        {
            RootObject2 js = JsonConvert.DeserializeObject<RootObject2>(json);
            foreach (Mensaje msj in js.mensajes.mensaje)
            {
                if(msj.IP == null)
                {
                    foreach(String IP in msj.nodos.IP)
                    {
                        post_enviarMsj(IP, msj.texto);
                    }
                }else
                {
                    post_enviarMsj(msj.IP, msj.texto);
                }
            }
        }

        private void post_enviarMsj(string ip, string texto)
        {
            try
            {
                string respuesta = "";
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["inorden"] = texto;
                    var response = client.UploadValues("http://" + ip + ":5000/mensaje", values);
                    var responseString = Encoding.Default.GetString(response);
                    respuesta = responseString;
                    MessageBox.Show(responseString);
                    //de una vez deberiamos ir llenando el datagridview pienso yo 
                }
                if (respuesta.Equals("true"))
                {
                    MessageBox.Show("Respuesta recibida: " + respuesta);
                }
                else
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
    }
}

