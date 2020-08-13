

using Semicrol.Cursos.Dominio;
using Semicrol.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Persistencia
{
    class FacturaRepository:IFacturaRepository
    {
        public void Insertar(Factura factura)
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into " +
                    "Facturas(numero, concepto) " +
                    "values (@Numero, @Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.Parameters.AddWithValue("@Concepto", factura.Concepto);

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


        public void Borrar(Factura factura)
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from Facturas where Numero=@Numero";

                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.ExecuteNonQuery();

            }
        }



        public Factura BuscarUno(int numero)
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
                    Factura factura = new Factura                       (Convert.ToInt32(lector["numero"]),
                       lector["concepto"].ToString());
                    return factura;

                }
                else
                {
                    return null;
                }
            }

        }

        public List<Factura> BuscarTodos()
        {

            List<Factura> lista = new List<Factura>();
            using (SqlConnection conexion =
          new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from Facturas";
                SqlCommand comando = new SqlCommand(sql, conexion);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(new Factura
                        (Convert.ToInt32(lector["numero"]),
                        lector["concepto"].ToString()));

                }

                return lista;
            }
        }
            public  List<Factura> BuscarTodos(FiltroFacturaNuevo filtro)
            {

                List<Factura> lista = new List<Factura>();
                using (SqlConnection conexion =
              new SqlConnection(CadenaConexion()))
                {
                    conexion.Open();
                    String sql = "select * from Facturas";
                    SqlCommand comando = new SqlCommand();
                    if (filtro.Numero != 0)
                    {
                        sql += " where Numero=@Numero";
                        comando.Parameters.AddWithValue("@Numero", filtro.Numero);
                        if (filtro.Concepto != null)
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
                        lista.Add(new Factura
                            (Convert.ToInt32(lector["numero"]),
                            lector["concepto"].ToString()));

                    }

                    return lista;
                }


            }

        public void Actualizar(Factura factura)
        {

            using (SqlConnection conexion =
            new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update Facturas " +
                    "set concepto =@Concepto where Numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.Parameters.AddWithValue("@Concepto", factura.Concepto);

                comando.ExecuteNonQuery();

            }
        }

    }



    }



    

