using LibreriaClaseslab2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LibreriaClaseslab2
{
    public class ListaEnlazada<T> : IEnumerable<T> where T : IComparable
    {

        public Nodolista <T> Primero { get; set; }
        public Nodolista <T> Ultimo { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Primero;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public void InsertarLista(T nuevo)
        {

            if (Primero == null)
            {
                Primero = new Nodolista<T>(nuevo);
                Ultimo = Primero;

            }
            else
            {
                var nuevonodo = new Nodolista<T>(nuevo);
                Ultimo.Next = nuevonodo;
                Ultimo = nuevonodo;
            }
            
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        



































































        /*public void Insertar()
        {
            Nodo nuevo = new Nodo();
            string[] lineas = File.ReadLines;
            foreach (var linea in lineas)
            {
                var id = linea.Split(',');
                string nid = Convert.ToString(id[1]);
                nid = nid.TrimEnd(',');
                int Iid = int.Parse(nid);
                var nombre = id[2].Split(',');
                string snombre = Convert.ToString(nombre[1]);
                snombre = snombre.TrimEnd(',');
                if (Convert.ToString(nombre[2].Substring(0)) == "\"")
                {
                    var separa1 = Convert.ToString(nombre[2]).Split('"');
                    var descripcion = separa1[2].Split('"');
                }
                var separa2 = descripcion[2].Split('"');
                var casa = separa2[2].Split('"');
                var precio = casa[2].Split(',');
                var existencia = precio[2];
                nuevo.Id = Iid;
                nuevo.Nombre = snombre;
                nuevo.Descripcion = descripcion;
                nuevo.Casap = casa;
                nuevo.Precio = precio;
                nuevo.Existencia = existencia;
            }



            if (primero == null)
            {
                primero = nuevo;
                ultimo = nuevo;
                nuevo.siguiente = null;
            }
            else
            {
                ultimo.siguiente = nuevo;
                ultimo = nuevo;
                nuevo.siguiente = null;
            }
        }*/

    }
}
