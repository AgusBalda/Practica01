using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Practica01.Domain;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;
using Practica01.Data.Utils;

namespace Practica01.Data
{
    internal class FacturaRepositoryADO : IFacturaRepository
    {
        private SqlConnection _connection;

        public FacturaRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public bool Delete(int id)
        {
            var parameters = new List<ParametersSQL>();
            parameters.Add(new ParametersSQL("@codigo", id));
            int rows = DataHelper.GetInstance().ExecuteSPDML("SP_REGISTRAR_BAJA_FACTURA", parameters);
            return rows == 1;
        }

        public List<Factura> GetAll()
        {
            List<Factura> lst = new List<Factura>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_FACTURAS", null);
            foreach (DataRow row in t.Rows)
            {
                int codigo = Convert.ToInt32(row["id_factura"]);
                string cliente = row["cliente"].ToString();
                int formapago = Convert.ToInt32(row["forma_pago"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);

                Factura oFactura = new Factura()
                {
                    Codigo = codigo,
                    Cliente = cliente,
                    FormaPago = formapago,
                    Fecha = fecha
                };
                lst.Add(oFactura);
            }
            return lst;
        }

        public Factura GetById(int id)
        {
            var parameters = new List<ParametersSQL>();
            parameters.Add(new ParametersSQL("@nroFactura", id));
            DataTable t = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS_POR_CODIGO", parameters);

            if (t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                int codigo = Convert.ToInt32(row["id_factura"]);
                string cliente = row["cliente"].ToString();
                int formapago = Convert.ToInt32(row["forma_pago"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);

                Factura oFactura = new Factura()
                {
                    Codigo = codigo,
                    Cliente = cliente,
                    FormaPago = formapago,
                    Fecha = fecha
                };
                return oFactura;

            }
            return null;
        }

        public bool Save(Factura oFactura, int id_articulo, int cantidad)
        {
            // nose como agregar tantos articulos como quiera el usuario en sp pero puedo hacer que se agregen
            // uno a la ves por cada peticion
            bool result = true;
            string query = "SP_GUARDAR_PRODUCTO";

            try
            {
                if (oFactura != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_factura", oFactura.Codigo);
                    cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                    cmd.Parameters.AddWithValue("@forma_pago", oFactura.FormaPago);
                    cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                    cmd.Parameters.AddWithValue("@id_articulo", id_articulo);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    result = cmd.ExecuteNonQuery() == 1; 
                }
            }
            catch (SqlException sqlEx)
            {
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }

    }
}

