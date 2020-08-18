using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Servicios
{
    interface IServicioFacturacion
    {
         void InsertarFactura(Factura f);
        List<Factura> BuscarTodasLasFacturas();
    }
}
