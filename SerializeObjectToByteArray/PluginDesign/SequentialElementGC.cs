using System;
using System.Xml.Serialization;

namespace PluginDesign.ScreenElements.SequentialElement
{

    [Serializable]
    [XmlRoot("elementoSecuencial")]
    public class SequentialElementGC
    {
        [XmlAttribute("id")]
        public string IdElement { get; set; }

        [XmlAttribute("esEstimuloCritico")]
        public bool EstimuloCritico { get; set; }

        [XmlAttribute("idView")]
        public string Id { get; set; }

        public SequentialElementGC()
        {
        }

       
    }
}
