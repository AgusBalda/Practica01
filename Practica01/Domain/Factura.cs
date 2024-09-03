using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Domain
{
    internal class Factura
    {
        public int Codigo { get; set; }
        public DateTime Fecha {  get; set; }
        public int Id_Forma_Pago { get; set; }
        public string Cliente { get; set; }
        public bool Activo {  get; set; }
        public override string ToString()
        {
            return "[" + Codigo + "]" + Cliente + " Fecha " + Fecha.Date + " estado:" + Activo;
        }
    }
}
