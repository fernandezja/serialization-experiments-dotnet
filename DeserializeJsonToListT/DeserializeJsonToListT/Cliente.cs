using System;
using System.Collections.Generic;
using System.Text;

namespace DeserializeJsonToListT
{
    public class Cliente
    {
        public int Numero { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCreacionUtc { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaModificacionUtc { get; set; }
        public int Proceso { get; set; }
        public string Usuario { get; set; }
        public string Estado { get; set; }
    }
}
