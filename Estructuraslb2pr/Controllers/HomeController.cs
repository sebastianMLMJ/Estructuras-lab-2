using Estructuraslb2pr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.ComponentModel;
using LibreriaClaseslab2;

namespace Estructuraslb2pr.Controllers
{
   
    public class HomeController : Controller
    {
        

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