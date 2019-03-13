using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estructuraslb2pr
{
    public class NodoArbol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int FactorEquilibrio;

        public NodoArbol Izquierdo;
        public NodoArbol Derecho;

        public NodoArbol()
        {
            Derecho = null;
            Izquierdo = null;
        }

    }
}