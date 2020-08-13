using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Dominio
{
    public class LineaFactura
    {

        public int Numero { get; set; }
        public int FacturasNumero { get; set; }

        public string ProductosID { get; set; }

        public int Unidades { get; set; }
    }
}
