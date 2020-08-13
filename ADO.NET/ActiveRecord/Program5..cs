using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program5
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f =
                FacturaActiveRecord.BuscarUno(1);

            f.Concepto = "otro concepto";
            f.Actualizar();
            Console.WriteLine(f.Concepto);
            Console.ReadLine();
        }
    }
}
