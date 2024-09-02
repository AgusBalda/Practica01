using Practica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Data
{
    internal interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura GetById(int id);
        bool Save(Factura factura, int idArticulo, int cantidad);
        bool Delete(int id);
    }
}
