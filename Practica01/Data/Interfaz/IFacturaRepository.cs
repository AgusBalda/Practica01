using Practica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Data.Interfaz
{
    internal interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura GetById(int id);
        bool Save(Factura factura);
        bool Delete(int id);
    }
}
