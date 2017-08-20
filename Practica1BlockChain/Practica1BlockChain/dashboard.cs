using System;

using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace Practica1Estructuras
{
    public partial class dashboard : Form
    {
        public static string texto = "";
        public static string ipLocal = "";
        public static string mascara = "";
        public static string carnet = "";
        private static readonly HttpClient client = new HttpClient();
        public dashboard()
        {

            InitializeComponent();
            
        }

        //private async  void consultarCarnet(string ipLocal)
        //{
        //    try
        //    {
        //        carnet = await client.GetStringAsync(ipLocal);
        //        Console.WriteLine(carnet);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
            
        //}
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

        public void cargarJson(String ip, String mascara, String carnet,String estado)
        {
            using (var client = new WebClient())
            {
                
                var values = new NameValueCollection();
                values["ip"] = "\""+ip+"\"";
                values["mascara"] = "\"" + mascara + "\"";
                values["carnet"] = "\"" + carnet + "\"";
                values["estado"] = "\"" + estado + "\"";

               
                //pero como ya tenemos el carnet deberiamos de una al momento de hacer el json hacer una consulta al otro nodo
                //y si nos devuelve el carnet esta conectado si no esta desconectado


                var response = client.UploadValues("http://localhost:5000/cargajson", values);

                var responseString = Encoding.Default.GetString(response);
                MessageBox.Show(responseString);
            }
        }


        private void button1_Click(object sender, EventArgs e)
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

                    //texto = texto.Replace("\"", "\\\"");
                    //json = json.Replace('\n', '\0');
                    //json = json.Replace(' ', '\0');
                    Console.WriteLine(texto);
                    //dynamic array = JsonConvert.DeserializeObject(texto);
                    RootObject jd = JsonConvert.DeserializeObject<RootObject>(texto);
                    ipLocal = jd.nodos.local;
                    mascara= jd.nodos.mascara;
                    //Mostrar en consola la ip
                    Console.WriteLine(ipLocal);
                    //consultarCarnet("http://localhost:5000/conectado");
                    string estado = "";

                    foreach (Nodo n in jd.nodos.nodo)
                    {
                            carnet = verCarnet(n.ip);
                        try
                        {
                            if (!carnet.Equals("no"))
                            {
                                estado = "Conectado";
                            }else
                            {
                                estado = "Desconectado";
                            }
                            cargarJson(n.ip, n.mascara, carnet,estado);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("ocurrio un error al insertar el nodo");
                        }                        
                        
                    }

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
        

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 f = new Practica1Estructuras.Form1();
            f.Show();
        }
    }
}
