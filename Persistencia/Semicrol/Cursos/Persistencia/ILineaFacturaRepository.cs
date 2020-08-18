using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Semicrol.Cursos.Persistencia
{
    public interface ILineaFacturaRepository
    {
         void Insertar(LineaFactura lf);
    }
}
