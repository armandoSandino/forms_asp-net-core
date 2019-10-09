using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Models;

using Microsoft.AspNetCore.Mvc.Rendering;// aqui esta el objeto SelectListItem

//una plantilla por defecto para un controlador
//podemos definirla mediante, asp-mvc-controller

namespace Forms.Controllers
{
    public class ClientesController : Controller
    {
        DbContext contexto = new DbContext();
        public IActionResult Index()
        {
            var cli = contexto.ListClientes;
            return View(cli);
        }
        //esto solo muestra el form
        [HttpGet]
        public IActionResult Create()
        { 
            Cliente cli = new Cliente();
            return CreateEdit("Create",cli);
            //return View();
        }
        //este se llama para guardar los datos del form
        [HttpPost]
        public IActionResult Create( Cliente cliente )
        //public IActionResult Create( String nombre, String email, String telefono )
        {
            contexto.ListClientes.Add( cliente );
            return View("Index", contexto.ListClientes );
        }

        [HttpGet]
        public IActionResult Edit( int id)
        {
            Cliente ci = contexto.ListClientes.Find(  x => x.Id  == id );    
            return CreateEdit("Edit", ci );
            //return View( ci );
        }

        [HttpPost]
        public IActionResult Edit( Cliente c )
        {
            int pos = contexto.ListClientes.FindIndex( x => x.Id == c.Id );
            contexto.ListClientes[pos] = c;
            return View("Index", contexto.ListClientes );
        }
        [HttpGet]
        public IActionResult Delete( int id )
        {
            int pos = contexto.ListClientes.FindIndex( x => x.Id == id );
            contexto.ListClientes.RemoveAt( pos );
            return View("Index", contexto.ListClientes );
        }
        public IActionResult CreateEdit(String action, Cliente cli )
        {
            List<SelectListItem> sexos = new List<SelectListItem>{
                new SelectListItem{ Value="Masculino", Text="Masculino"},
                new SelectListItem{ Value="Femenino",Text="Femenino"},
            };
            ViewData["Generos"] = sexos;
            ViewData["Action"] = action;
            return View("CreateEdit", cli );
        }
    }
}