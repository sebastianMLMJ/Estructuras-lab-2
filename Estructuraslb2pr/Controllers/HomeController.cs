using Estructuraslb2pr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.ComponentModel;

namespace Estructuraslb2pr.Controllers
{
   
    public class HomeController : Controller
    {
        public static Lista<Nodo> NuevaLista = new Lista<Nodo>();
        public static LinkedList<Nodo> Lista = new LinkedList<Nodo>();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
           
            return View(NuevaLista);
        }
        [HttpGet]
        public ActionResult Formulario()
        {

            return View();
        }
        /*[HttpPost]
        public ActionResult Formulario(int Id, string Nombre, string Descripcion, string Casap, double Precio, int Existencia)
        {

            NuevaLista.Insertar(Id,Nombre,Descripcion,Casap, Precio, Existencia );
            
            
            return View();
        }*/
    }
}