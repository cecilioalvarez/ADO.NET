using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Dominio
{
    public class LineaFactura
    {
        public Factura factura {get;set;}
        public int Numero { get; set; }
        public string ProductosID { get; set; }

        public LineaFactura( int numero, Factura factura)
        {
            this.factura = factura;
            Numero = numero;
        }

        public int Unidades { get; set; }

        public override bool Equals(object obj)
        {
            return obj is LineaFactura factura &&
                   Numero == factura.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + Numero.GetHashCode();
        }
    }
}
