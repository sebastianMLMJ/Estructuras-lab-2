using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClaseslab2
{
    public class Nodolista<T> 
    {
        public T Value;
        public Nodolista<T> Next;

        public Nodolista(T Valuetype)
        {
            Value = Valuetype;
            Next = null;
        }
    }
}
