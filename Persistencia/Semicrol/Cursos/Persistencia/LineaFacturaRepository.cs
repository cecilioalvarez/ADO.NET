using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Semicrol.Cursos.Persistencia
{
   public class LineaFacturaRepository : ILineaFacturaRepository
    {
        public void Insertar(LineaFactura lf)
        {
                using (SqlConnection conexion =
                new SqlConnection(CadenaConexion()))
                {
                    conexion.Open();
                    String sql = "insert into " +
                        "LineasFactura(numero, facturas_numero,unidades,productos_id) " +
                        "values (@Numero, @FacturasNumero,@Unidades,@productos_id)";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Numero",lf.Numero);
                    comando.Parameters.AddWithValue("@FacturasNumero", lf.factura.Numero);
                comando.Parameters.AddWithValue("@Unidades", lf.Unidades);
                comando.Parameters.AddWithValue("@productos_id", lf.ProductosID);


                comando.ExecuteNonQuery();

                }
            }

            private static string CadenaConexion()
            {
                ConnectionStringSettings settings =
                    ConfigurationManager
                    .ConnectionStrings["miconexion"];
                String cadena = settings.ConnectionString;
                return cadena;
            }



        
    }
}
