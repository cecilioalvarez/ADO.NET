using Persistencia.Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Servicios;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Servicios.Semicrol.Cursos.Servicios
{
    [Transaction]
    public class ServicioFacturas : IServicioFacturacion
    {

        private IFacturaRepository repoFacturas;
        private ILineaFacturaRepository repoLineas;

        public ServicioFacturas(IFacturaRepository repoFacturas, ILineaFacturaRepository repoLineas)
        {
            this.repoFacturas = repoFacturas;
            this.repoLineas = repoLineas;
        }

   
        public void InsertarFactura(Factura f)
        {

            repoFacturas.Insertar(f);
            foreach (LineaFactura lf in f.lineas)
            {
                repoLineas.Insertar(lf);
            }
        }

        public List<Factura> BuscarTodasLasFacturas()
        {
           return  repoFacturas.BuscarTodos();
        }


    }
}
