using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program6
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f = FacturaActiveRecord.BuscarUno(1);

            List<LineasFacturaActiveRecord> lista =
                f.BuscarLineas();

           foreach (LineasFacturaActiveRecord lf  in lista)
            {

                Console.WriteLine(lf.ProductoId);
                Console.WriteLine(lf.Unidades);

            }

            List<FacturaLineaDTO> lista2 =
                FacturaActiveRecord.BuscarFacturaLinea();

            foreach (FacturaLineaDTO lf in lista2)
            {

                Console.WriteLine(lf.Unidades);
                Console.WriteLine(lf.NumeroFactura);

            }


            Console.ReadLine();
        }
    }
}
