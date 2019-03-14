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
                var descripcion="";
                if (Convert.ToString(nombre[2].Substring(0)) == "\"")
                {
                    var separa1 = Convert.ToString(nombre[2]).Split('"');
                    var separados= Convert.ToString(separa1[2].Split(','));
                    separa1[1] = String.Concat(separados[1]+" "+separados[2]);//revisar en que posiciones guarda el split 
                    descripcion = Convert.ToString(separa1[1].Split('"'));
                    descripcion = Convert.ToString(descripcion[1]).TrimEnd('"');                    
                }
                else
                {
                    var separa1 = Convert.ToString(nombre[2].Split(','));
                    descripcion = Convert.ToString(separa1[2]);
                    descripcion = Convert.ToString(descripcion[1]).TrimEnd(',');
                }
                var separa2 = "";
                var casa = "";
                if (Convert.ToString(descripcion[2]).Substring(0) == "\"")
                {
                    separa2 = Convert.ToString(Convert.ToString(descripcion[2]).Split('"'));
                    var separados = Convert.ToString(Convert.ToString(separa2[2]).Split(','));//revisar en que posicion guarda el split
                    separa2 = string.Concat(separados[1] + " " + separados[2]);
                    casa = Convert.ToString(Convert.ToString(separa2[1]).Split('"'));
                    casa = Convert.ToString(casa[1]).TrimEnd('"');
                }
                else
                {
                    separa2 = Convert.ToString(Convert.ToString(descripcion[2]).Split(','));
                    casa = Convert.ToString(separa2[1]);
                    casa = Convert.ToString(casa[1]).TrimEnd(',');
                }
                
                var precio = Convert.ToString(casa[2]).Split(',');
                precio[1] = Convert.ToString(precio[1].TrimEnd(','));
                double dprecio = Convert.ToDouble(precio[1]);
                var existencia = precio[2];
                int iexistencia = int.Parse(existencia);
                
                nuevo.Id = Iid;
                nuevo.Nombre = snombre;
                nuevo.Descripcion = descripcion;
                nuevo.Casap = casa;
                nuevo.Precio = dprecio;
                nuevo.Existencia = iexistencia;
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