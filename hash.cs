using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class hash
    {
        public int tamanioInicial { get; set; }
        public int porMin { get; set; }
        public int porMax { get; set; }
        public nodoAbb[] arreglo { get; set; }

        public hash()
        {
            tamanioInicial = 43;
            arreglo = new nodoAbb[tamanioInicial];
            for (int i = 0; i < tamanioInicial; i++)
            {//lenar nulo el arreglo
                arreglo[i] = null;
            }
            porMax = 50;
            porMin = 30;
        }

        public string graficar()
        {
            string g = "";
            if (arreglo != null)
            {
                g = "digraph g {\n rankdir=UD; \n node[shape = box]; \n ";
                g += "nodoDensidad[label=\"Densidad: " + densidad(this.arreglo).ToString() + " \"]; \n ";
                g += "nodoTama[label = \"Tamaño: " + tamanioInicial.ToString() + "\"];\n";
                for (int i = 0; i < arreglo.Length; i++)
                {
                    if (arreglo[i] != null)
                    {
                        nodoAbb a = arreglo[i];
                        g += "nodo" + i + "[label=\"Posicion: "+(i+1)+"\n Usuario: " + a.nickName + " \n Correo: " + a.email + " \n Password: " + a.password + "\"]; \n";
                    }
                    else
                    {
                        g += "nodo" + i + "[label=\" Posicion vacia " + (i + 1) + " \"]; \n";
                    }
                }
                for (int i = 0; i < arreglo.Length; i++)
                {
                    if (i < (arreglo.Length - 1))
                    {
                        g += "nodo" + i + " -> nodo" + (i + 1) + ";\n";
                    }
                }
            }
            g += "}\n";
            return g;
        }

        public int funcionHash(string nick, int tam)
        {//funcion hash me va a devolver la posicion en el vector
         //funcion de plegamiento
            int pos = 0;
            char[] array = nick.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                pos += (int)array[i];
            }

            pos = pos % tam;
            return pos;

        }

        public int rehashing(int posActual, nodoAbb [] arreglo)
        {
            int i = 1;
            while (arreglo[posActual] != null)
            {
                i = i * i;
                posActual = posActual + i;
                i++;
                if(i == (arreglo.Length - 1))
                {
                    posActual = 0;
                    i = 0;
                    //reiniciamos 
                }
                if(posActual == (arreglo.Length-1) || posActual == arreglo.Length || posActual > arreglo.Length) 
                {
                    posActual = 0;
                    i = 0;
                }
            }
            return posActual;
        }

        public int densidad(nodoAbb [] arreglo)
        {
            int ocupados = 0;
            if (arreglo != null)
            {
                for (int i = 0; i < arreglo.Length; i++)
                {
                    if (arreglo[i] != null)
                    {
                        ocupados++;
                    }
                }
            }
            double densidad = 0;
            int tam = arreglo.Length;
            densidad = ((double)ocupados / (double)tam);
            densidad = densidad * 100.00;
            return (int)densidad;
        }

        public int ocupados(nodoAbb [] arreglo)
        {
            int ocupados = 0;
            if (arreglo != null)
            {
                for (int i = 0; i < arreglo.Length; i++)
                {
                    if (arreglo[i] != null)
                    {
                        ocupados++;
                    }
                }
            }
            return ocupados;
        }

        public void Redimensionar(nodoAbb [] arreglo)
        {
            int nt = nuevoTamanio(ocupados(arreglo));
            nodoAbb[] nuevoArray = new nodoAbb[nt];
            for(int i = 0; i < arreglo.Length; i++)
            {
                if(arreglo[i] != null)
                {
                    insertar(arreglo[i], nuevoArray);
                }
            }
            this.arreglo = nuevoArray;
            this.tamanioInicial = nt;

            
        }
        public bool necesitaRedimension(nodoAbb [] arreglo)
        {
            int dens = densidad(arreglo);
            if(dens < porMin || dens > porMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void insertar(nodoAbb nodo, nodoAbb [] arreglo)
        {
            int pos = funcionHash(nodo.nickName, arreglo.Length);
            if(arreglo[pos] == null)
            {
                arreglo[pos] = nodo;
            }
            else
            {
                int nuevaPos = rehashing(pos, arreglo);
                if(arreglo[nuevaPos] == null)
                {
                    arreglo[nuevaPos] = nodo;
                }
                else
                {
                    MessageBox.Show("No funciono el rehashing");
                }
            }
        }

        public int nuevoTamanio(int ocupados)
        {
            double res = 0.00;
            res = (((double)ocupados / (double)35) );
            res = res * 100.00;
            
            return (int)res;//siempre que tenga una factor de 35 %
        }
    }
}
