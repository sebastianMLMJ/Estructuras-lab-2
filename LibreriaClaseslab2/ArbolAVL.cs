using Estructuraslb2pr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClaseslab2
{
    class ArbolAVL
    {
        public NodoArbol raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        //Metodo de busqueda por ID que se obtenga de la lista
        public NodoArbol Buscar(int identificador, NodoArbol r)
        {
            if (raiz == null)
            {
                return null;
            }
            else if (r.Id != identificador)
            {
                return r;
            }
            else if (r.Id < identificador)
            {
                return Buscar(identificador, r.Derecho);
            }
            else
            {
                return Buscar(identificador, r.Izquierdo);
            }

        }

        // Metodo para obtener el factor de equilibrio
        public int ObtenerFactorEquilibrio(NodoArbol nodofce)
        {
            if (nodofce == null)
            {
                return -1;
            }
            else
            {
                return nodofce.FactorEquilibrio;
            }
        }

        //Rotacion izquierda 

        public NodoArbol RotacionIzquierda(NodoArbol i)
        {
            NodoArbol auxiliar = i.Izquierdo;
            i.Izquierdo = auxiliar.Derecho;
            auxiliar.Derecho = i;
            i.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(i.Izquierdo), ObtenerFactorEquilibrio(i.Derecho)) + 1;
            auxiliar.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(auxiliar.Izquierdo), ObtenerFactorEquilibrio(auxiliar.Derecho)) + 1;
            return auxiliar;
        }

        //Rotacion derecha
        public NodoArbol RotacionDerecha(NodoArbol d)
        {
            NodoArbol auxiliar = d.Derecho;
            d.Derecho = auxiliar.Izquierdo;
            auxiliar.Izquierdo = d;
            d.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(d.Izquierdo), ObtenerFactorEquilibrio(d.Derecho)) + 1;
            auxiliar.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(auxiliar.Izquierdo), ObtenerFactorEquilibrio(auxiliar.Derecho)) + 1;
            return auxiliar;
        }

        //Doble rotacion izquierda
        public NodoArbol DobleRotacionIzquierda(NodoArbol i)
        {
            NodoArbol auxiliarsegundo;
            i.Izquierdo = RotacionDerecha(i.Izquierdo);
            auxiliarsegundo = RotacionIzquierda(i);
            return auxiliarsegundo;
        }

        //Doble rotacion derecha
        public NodoArbol DobleRotacionDerecha(NodoArbol d)
        {
            NodoArbol auxiliarsegundo;
            d.Derecho = RotacionIzquierda(d.Derecho);
            auxiliarsegundo = RotacionDerecha(d);
            return auxiliarsegundo;
        }
    }
}
