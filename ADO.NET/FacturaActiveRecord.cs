using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaActiveRecord
    {
        public int Numero { get; set; }
        public string Concepto { get; set; }
        public FacturaActiveRecord(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }

        public  static List<FacturaActiveRecord> BuscarTodos()
        {

            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);
                
                SqlDataReader lector=comando.ExecuteReader();

                while(lector.Read())
                {
                    lista.Add(new FacturaActiveRecord
                        (Convert.ToInt32(lector["numero"]), 
                        lector["concepto"].ToString()));
                    
                }

                return lista;
            }


        }


        public void Borrar()
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from  " +
                    "Facturas where Numero=" + Numero;
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();

            }
        }




        public void Insertar()
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into " +
                    "Facturas(numero, concepto) " +
                    "values (" + Numero + ", '" + Concepto + "')";
                SqlCommand comando = new SqlCommand(sql, conexion);
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
