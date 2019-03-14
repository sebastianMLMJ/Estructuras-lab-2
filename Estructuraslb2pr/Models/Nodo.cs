using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Estructuraslb2pr.Models
{
    public class Nodo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Casap { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }

        public Nodo siguiente;

    }


}