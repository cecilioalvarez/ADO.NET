using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program2
    {
        static void Main(string[] args)
        {
            SqlConnection conexion =
                new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\cecilio\Documents\prueba.mdf; Integrated Security = True; Connect Timeout = 30");
            conexion.Open();
            String sql = "insert into " +
                "Facturas(numero, concepto) " +
                "values(3, 'otra')";
            SqlCommand comando = new SqlCommand(sql,conexion);
            comando.ExecuteNonQuery();

            Console.ReadLine();
        }
    }
}
