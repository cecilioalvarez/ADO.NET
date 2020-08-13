using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Persistencia.Filtros
{
    class FiltroFacturaNuevo
    {
        private int _numero;
        private string _concepto;
       
        public int Numero
        {
            get
            {
                return _numero;
            }
        }

        public string Concepto
        {
            get
            {
                return _concepto;
            }
        }


 
        // programacion fluida
        public  FiltroFacturaNuevo  AddNumero(int numero)
        {
           _numero = numero;
            return this;

           
        }

        public   FiltroFacturaNuevo  AddConcepto(string concepto)
        {
            _concepto = concepto;
            return this;
            
        }

       
        
    }
}
