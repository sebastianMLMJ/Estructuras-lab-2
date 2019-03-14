using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estructuraslb2pr
{
    public class NodoArbol<T>
    {
        public T Value { get; set; }
        public NodoArbol<T> izquierda { get; set; }
        public NodoArbol<T> derecha { get; set; }
        public string Llave { get; set; }
        public int Linea { get; set; }



        public int Id { get; set; }
        public string Nombre { get; set; }
        public int FactorEquilibrio;

       

        public NodoArbol()
        {
            derecha = null;
            izquierda = null;
        }

    }
}