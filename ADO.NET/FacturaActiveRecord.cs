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

        public static List<FacturaActiveRecord> BuscarTodos(FiltroFactura filtro)
        {

            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand();
                if (filtro.Numero!=0)
                {
                    sql += " where Numero=@Numero";
                    comando.Parameters.AddWithValue("@Numero", filtro.Numero);
                    if (filtro.Concepto!=null)
                    {

                        sql += " and Concepto=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }
                else
                {


                    if (filtro.Concepto != null)
                    {

                        sql += " where Concepto=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);

                    }


                }



                comando.Connection = conexion;
                comando.CommandText = sql;

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(new FacturaActiveRecord
                        (Convert.ToInt32(lector["numero"]),
                        lector["concepto"].ToString()));

                }

                return lista;
            }


        }












        public static List<FacturaActiveRecord> BuscarPorConcepto(string concepto)
        {

            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas where concepto = @Concepto";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Concepto", concepto);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(new FacturaActiveRecord
                        (Convert.ToInt32(lector["numero"]),
                        lector["concepto"].ToString()));

                }

                return lista;
            }


        }


        public  List<LineasFacturaActiveRecord> BuscarLineas()
        {

            List<LineasFacturaActiveRecord> lista = new List<LineasFacturaActiveRecord>();
            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from LineasFactura where facturas_numero = @FacturasNumero";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@FacturasNumero", Numero);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(
                        new LineasFacturaActiveRecord(Convert.ToInt32(lector["numero"])
                        , lector["productos_id"].ToString()
                        , Convert.ToInt32(lector["unidades"]), 
                        Convert.ToInt32(lector["facturas_Numero"])));
                       
                }

                return lista;
            }


        }

        public  static List<FacturaLineaDTO> BuscarFacturaLinea()
        {

            List<FacturaLineaDTO> lista = new List<FacturaLineaDTO>();
            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas" +
                    " inner join" +
                    "  LineasFactura " +
                    "on Facturas.numero=LineasFactura.Facturas_numero";


                SqlCommand comando = new SqlCommand(sql, conexion);
                 SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(
                        new FacturaLineaDTO(Convert.ToInt32(lector["numero"])
                        , lector["concepto"].ToString()
                        , Convert.ToInt32(lector["unidades"]),
                        lector["productos_Id"].ToString()));

                }

                return lista;
            }


        }



        public static FacturaActiveRecord BuscarUno(int numero)
        {

            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas where Numero=@Numero";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", numero);
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    FacturaActiveRecord factura = new FacturaActiveRecord
                       (Convert.ToInt32(lector["numero"]),
                       lector["concepto"].ToString());
                    return factura;

                }else
                {
                    return null;
                }
            }


        }


        public void Borrar()
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from Facturas where Numero=@Numero";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
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
                    "values (@Numero, @Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Concepto", Concepto);

                comando.ExecuteNonQuery();

            }
        }


        public void Actualizar()
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update Facturas " +
                    "set concepto =@Concepto where Numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Concepto", Concepto);

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
