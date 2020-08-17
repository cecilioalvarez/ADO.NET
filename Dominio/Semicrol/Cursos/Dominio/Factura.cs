using System;
using System.Collections.Generic;
using System.Text;

namespace Semicrol.Cursos.Dominio
{
   public  class Factura
    {
        public Factura(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
            lineas = new List<LineaFactura>();
        }

        public Factura(int numero)
        {
            Numero = numero;
            lineas = new List<LineaFactura>();
        }

        public int Numero { get; set; }
        public string Concepto { get; set; }
        
        public List<LineaFactura> lineas { get; set; }

        public void AddLinea(LineaFactura linea)
        {

            this.lineas.Add(linea);
        }

        public void RemoveLinea(LineaFactura linea)
        {

            this.lineas.Remove(linea);
        }

        public override bool Equals(object obj)
        {
            return obj is Factura factura &&
                   Numero == factura.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + Numero.GetHashCode();
        }
    }
}
