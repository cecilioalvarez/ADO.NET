
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program7
    {
        static void Main(string[] args)
        {
            /*
            IFacturaRepository repositorio = new FacturaRepository();
            //repositorio
              //  .Borrar(new Factura(20));


            Factura factura=repositorio.BuscarUno(1);
            Console.WriteLine(factura.Concepto);

            FiltroFacturaNuevo filtro
                = new FiltroFacturaNuevo();
                filtro.AddConcepto("televisor").AddNumero(1);

        
              List <Factura> facturas = repositorio.BuscarTodos(filtro);

            foreach(Factura f in facturas)
            {
                Console.WriteLine(f.Numero);
                Console.WriteLine(f.Concepto);

            }

            */

            IFacturaRepository repo = new FacturaRepository();

            List<Factura> lista=repo.BuscarTodosConLineas();

            foreach (Factura f in lista )
            {

                Console.WriteLine(f.Concepto);
                foreach (LineaFactura lf in f.lineas)
                {

                    Console.WriteLine(lf.Unidades);
                }
            }
            Console.ReadLine();
        }
    }
}
