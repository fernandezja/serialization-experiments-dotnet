using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializeJsonToDynamic
{
    public class DolarViewModel
    {
        public List<ListaValoresDolarViewModel> Dolares { get; set; }
    }

    public class ListaValoresDolarViewModel
    {
        public string Valor { get; set; }
        public string Fecha { get; set; }
    }

}
