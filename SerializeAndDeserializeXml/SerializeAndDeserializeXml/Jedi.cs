using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeAndDeserializeXml
{
    [XmlRoot(ElementName = "jedi", Namespace = "https://www.starwars.com")]
    public class Jedi
    {
        [XmlElement(ElementName ="id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "planet", IsNullable = true)]
        public string Planet  { get; set; }

        //[XmlElement(ElementName = "amount", IsNullable = true)]
        //public double? Amount { get; set; }
        [XmlIgnore]
        public double? Amount { get; set; }

        [XmlElement(ElementName = "amount")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string AmountOnlyJustToDeserialize
        {
            get
            {
                if (Amount.HasValue) {
                    return Amount.Value.ToString("0.##");
                }
                return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) {
                    Amount = null;
                }
                else
                {
                    Amount = double.Parse(value);
                }
                
            }
        }
    }
}
