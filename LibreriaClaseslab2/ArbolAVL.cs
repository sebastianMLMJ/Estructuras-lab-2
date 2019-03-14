using Estructuraslb2pr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClaseslab2
{
    class ArbolAVL<T>
    {
        public NodoArbol<T> raiz { get; set; }

        public ArbolAVL()
        {
            raiz = null;
        }

        public void Agregar(T valor, string nuevaLlave, int linea)
        {
            if (raiz == null)
            {
                NodoArbol<T> nuevoNodo = new NodoArbol<T>();
                nuevoNodo.Value = valor;
                nuevoNodo.Llave = nuevaLlave;
                nuevoNodo.Linea = linea;
                raiz = nuevoNodo;
            }
            else
            {
                Agregar(valor, nuevaLlave, raiz, linea);
            }
        }

        private void Agregar(T valor, string nuevaLlave, NodoArbol<T> nodo, int linea)
        {

            NodoArbol<T> tmp = nodo;
            //nuevaLlave < tmp.llave
            if (nuevaLlave.CompareTo(tmp.Llave) == -1)
            {
                if (tmp.izquierda == null)
                {
                    NodoArbol<T> nuevoNodo = new NodoArbol<T>();
                    nuevoNodo.Value = valor;
                    nuevoNodo.Llave = nuevaLlave;
                    nuevoNodo.Linea = linea;
                    tmp.izquierda = nuevoNodo;
                }
                else
                {
                    Agregar(valor, nuevaLlave, tmp.izquierda, linea);
                }
            }
            else
            {
                if (tmp.derecha == null)
                {
                    NodoArbol<T> nuevoNodo = new NodoArbol<T>();
                    nuevoNodo.Value = valor;
                    nuevoNodo.Llave = nuevaLlave;
                    nuevoNodo.Linea = linea;
                    tmp.derecha = nuevoNodo;
                }
                else
                {
                    Agregar(valor, nuevaLlave, tmp.derecha, linea);
                }
            }
        }

        public void Eliminar(string nuevaLlave)
        {
            NodoArbol<T> anterior = null, actual;
            actual = raiz;
            while (actual != null)
            {
                if (actual.Llave == nuevaLlave)
                {
                    break;
                }
                anterior = actual;
                if (nuevaLlave.CompareTo(actual.Llave) == -1)
                    actual = actual.izquierda;
                else
                    actual = actual.derecha;
            }

            if (actual.izquierda == null && actual.derecha == null)
            {
                if (nuevaLlave.CompareTo(anterior.Llave) == -1)
                    anterior.izquierda = null;
                else
                    anterior.derecha = null;
            }

            else if (actual.izquierda != null || actual.derecha != null)
            {
                if (actual.izquierda != null)
                {
                    if (nuevaLlave.CompareTo(anterior.Llave) == -1)
                        anterior.izquierda = actual.izquierda;
                    else
                        anterior.derecha = actual.izquierda;
                }
                else
                {
                    if (nuevaLlave.CompareTo(anterior.Llave) == -1)
                        anterior.izquierda = actual.derecha;
                    else
                        anterior.derecha = actual.derecha;
                }
            }

            else
            {
                NodoArbol<T> temp = new NodoArbol<T>();
                temp = actual.derecha;
                while (temp.izquierda != null)
                {
                    anterior = temp;
                    temp = temp.izquierda;
                }

                actual = temp;

                if (temp.izquierda != null)
                {
                    if (nuevaLlave.CompareTo(anterior.Llave) == -1)
                        anterior.izquierda = temp.izquierda;
                    else
                        anterior.derecha = temp.izquierda;
                }
                else
                {
                    if (nuevaLlave.CompareTo(anterior.Llave) == -1)
                        anterior.izquierda = temp.derecha;
                    else
                        anterior.derecha = temp.derecha;
                }

            }

            //Metodo de busqueda por ID que se obtenga de la lista
             NodoArbol<T> Buscar(int identificador, NodoArbol<T> r)
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
                    return Buscar(identificador, r.derecha);
                }
                else
                {
                    return Buscar(identificador, r.izquierda);
                }

            }

        }
        // Metodo para obtener el factor de equilibrio
        public int ObtenerFactorEquilibrio(NodoArbol<T> nodofce)
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

        public NodoArbol<T> RotacionIzquierda(NodoArbol<T> i)
        {
            NodoArbol<T> auxiliar = i.izquierda;
            i.izquierda = auxiliar.derecha;
            auxiliar.derecha = i;
            i.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(i.izquierda), ObtenerFactorEquilibrio(i.derecha)) + 1;
            auxiliar.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(auxiliar.izquierda), ObtenerFactorEquilibrio(auxiliar.derecha)) + 1;
            return auxiliar;
        }

        //Rotacion derecha
        public NodoArbol<T> RotacionDerecha(NodoArbol<T> d)
        {
            NodoArbol<T> auxiliar = d.derecha;
            d.derecha = auxiliar.izquierda;
            auxiliar.izquierda = d;
            d.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(d.izquierda), ObtenerFactorEquilibrio(d.derecha)) + 1;
            auxiliar.FactorEquilibrio = Math.Max(ObtenerFactorEquilibrio(auxiliar.izquierda), ObtenerFactorEquilibrio(auxiliar.derecha)) + 1;
            return auxiliar;
        }

        //Doble rotacion izquierda
        public NodoArbol<T> DobleRotacionIzquierda(NodoArbol<T> i)
        {
            NodoArbol<T> auxiliarsegundo;
            i.izquierda = RotacionDerecha(i.izquierda);
            auxiliarsegundo = RotacionIzquierda(i);
            return auxiliarsegundo;
        }

        //Doble rotacion derecha
        public NodoArbol<T> DobleRotacionDerecha(NodoArbol<T> d)
        {
            NodoArbol<T> auxiliarsegundo;
            d.derecha = RotacionIzquierda(d.derecha);
            auxiliarsegundo = RotacionDerecha(d);
            return auxiliarsegundo;
        }

        public IEnumerable<NodoArbol<T>> RecorridoPreOrden(NodoArbol<T> nodo)
        {

            if (nodo.izquierda != null)
            {
                foreach (NodoArbol<T> nodoIzqActual in RecorridoPreOrden(nodo.izquierda))
                    yield return nodoIzqActual;
                //Va a agarrar la raiz el sub arbor
                // SE va a ir por todo el lado izquierdo
                //Recorrido preorden
                //yield hace el cast al hacer el return
            }
            else if (nodo.derecha != null)
            {
                foreach (NodoArbol<T> nodoDerechoActual in RecorridoPreOrden(nodo.derecha))
                    yield return nodoDerechoActual;
            }
        }

        public IEnumerable<NodoArbol<T>> RecorridoInorden(NodoArbol<T> nodo)
        {

            if (nodo != null)
            {
                RecorridoInorden(nodo.izquierda);
                yield return nodo;
                RecorridoInorden(nodo.derecha);
            }
        }

        public IEnumerable<NodoArbol<T>> RecorridoPostOrden(NodoArbol<T> nodo)
        {

            if (nodo != null)
            {
                RecorridoPostOrden(nodo.izquierda);
                RecorridoPostOrden(nodo.derecha);
                yield return nodo;

            }
        }
    }
}
