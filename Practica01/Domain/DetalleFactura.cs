using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Domain
{
    internal class DetalleFactura
    {
        public int Codigo {  get; set; }
        public int Id_Articulo {  get; set; }
        public int Cantidad {  get; set; }
        public int Id_Factura {  get; set; }

    }
}
