
using Semicrol.Cursos.Dominio;
using Semicrol.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Persistencia
{
    interface IFacturaRepository
    {
        void  Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);

        List<Factura> BuscarTodos();
        List<Factura> BuscarTodos(FiltroFacturaNuevo filtro);
        Factura BuscarUno(int numero);


    }
}
