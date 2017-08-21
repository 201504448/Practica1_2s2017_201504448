using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1Estructuras
{
    public class NodosXml
    {
        public List<string> IP { get; set; }
    }

    public class Mensaje
    {
        public NodosXml nodos { get; set; }
        public string texto { get; set; }
        public string IP { get; set; }
    }

    public class Mensajes
    {
        public List<Mensaje> mensaje { get; set; }
    }

    public class RootObject2
    {
        public Mensajes mensajes { get; set; }

        
    }

    

}
