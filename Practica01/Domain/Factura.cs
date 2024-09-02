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
        public int FormaPago { get; set; }
        public string Cliente { get; set; }
        public override string ToString()
        {
            return "[" + Codigo + "]" + Cliente;
        }
    }
}
