using Practica01.Data.ADO;
using Practica01.Data.Interfaz;
using Practica01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Services
{
    internal class FacturaManager
    {
        private IFacturaRepository _repositorio;

        public FacturaManager()
        {
            _repositorio = new FacturaRepositoryADO();
        }

        public List<Factura> GetFacturas()
        {
            return _repositorio.GetAll();
        }

        public Factura GetFacturaPorId(int id)
        {
            return _repositorio.GetById(id);
        }

        public bool SaveFacturas(Factura factura)
        {
            return _repositorio.Save(factura);
        }

        public bool DeleteFactura(int id)
        {
            return _repositorio.Delete(id);
        }
    }
}
