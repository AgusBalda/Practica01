using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Practica01.Domain;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Practica01.Data.Utils;
using Practica01.Data.Interfaz;

namespace Practica01.Data.ADO
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
            parameters.Add(new ParametersSQL("@id", id));
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
                int codigo = Convert.ToInt32(row["id"]);
                string cliente = row["cliente"].ToString();
                int formapago = Convert.ToInt32(row["id_forma_pago"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                bool activo = Convert.ToBoolean(row["esta_activo"]);
                Factura oFactura = new Factura()
                {
                    Codigo = codigo,
                    Cliente = cliente,
                    Id_Forma_Pago = formapago,
                    Fecha = fecha,
                    Activo = activo
                };
                lst.Add(oFactura);
            }
            return lst;
        }

        public Factura GetById(int id)
        {
            var parameters = new List<ParametersSQL>();
            parameters.Add(new ParametersSQL("@id", id));
            DataTable t = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURA_CODIGO", parameters);

            if (t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                int codigo = Convert.ToInt32(row["id"]);
                string cliente = row["cliente"].ToString();
                int formapago = Convert.ToInt32(row["id_forma_pago"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                bool activo = Convert.ToBoolean(row["esta_activo"]);
                Factura oFactura = new Factura()
                {
                    Codigo = codigo,
                    Cliente = cliente,
                    Id_Forma_Pago = formapago,
                    Fecha = fecha,
                    Activo = activo
                };
                return oFactura;

            }
            return null;
        }

        public bool Save(Factura oFactura)
        {
            bool result = true;
            string query = "SP_GUARDAR_FACTURA";

            try
            {
                if (oFactura != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", oFactura.Codigo);
                    cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                    cmd.Parameters.AddWithValue("@forma_pago", oFactura.Id_Forma_Pago);
                    cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException sqlEx)
            {
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }

    }
}

