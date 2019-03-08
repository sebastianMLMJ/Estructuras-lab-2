using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Estructuraslb2pr.Models
{
    public class Lista<T>
    {
        Nodo primero = new Nodo();
        Nodo ultimo = new Nodo();

        public Lista()
        {
            primero = null;
            ultimo = null;
        }


        public void Insertar()
        {
            Nodo nuevo = new Nodo();
            string[] lineas = File.ReadLines;
            foreach (var linea in lineas)
            {
                var id = linea.Split(',');
                string nid = Convert.ToString(id[1]);
                nid = nid.TrimEnd(',');
                int Iid = int.Parse(nid);
                var nombre=id[2].Split(',');
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
        }

    }
}