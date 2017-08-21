using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
    namespace Xml2CSharp
    {
        [XmlRoot(ElementName = "nodos")]
        public class Nodos
        {
            [XmlElement(ElementName = "IP")]
            public List<string> IP { get; set; }
        }

        [XmlRoot(ElementName = "mensaje")]
        public class Mensaje
        {
            [XmlElement(ElementName = "nodos")]
            public Nodos Nodos { get; set; }
            [XmlElement(ElementName = "texto")]
            public string Texto { get; set; }
            [XmlElement(ElementName = "IP")]
            public string IP { get; set; }
        }

        [XmlRoot(ElementName = "mensajes")]
        public class Mensajes
        {
            [XmlElement(ElementName = "mensaje")]
            public List<Mensaje> Mensaje { get; set; }
        }

    }


