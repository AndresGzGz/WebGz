using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGz.Models;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace WebGz.Controllers
{
    public class ClienteController : Controller
    {
        
        public IActionResult Index()
        {
            var db = new bdgzContext ();
            var clientes = db.Clientes.ToList(); 
            return View(clientes);  
        }
        
        /* public IActionResult Index(int? page)
        {
            var db = new bdgzContext ();
            var pageNumber =page ?? 1;
            int pageSize = 5;
            var clientes = db.Clientes.ToPagedList(pageNumber,pageSize);
            return View(clientes);  
        }
       */
        [Authorize]
        public IActionResult Crear()
        {
            return View();  
        }
        
        [HttpPost]

        public IActionResult Crear(Cliente miCliente)
        {
            var db = new bdgzContext();
            var existe = db.Clientes.Find(miCliente.Idcliente);
            
                if (existe==null){
                    db.Clientes.Add(miCliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Msj"]=$"El IDCliente {miCliente.Idcliente} ya existe";
                    return View();
                }

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var db = new bdgzContext();
            var miCliente = db.Clientes.Find(id);
            return View(miCliente);  
        }
        [HttpPost]
        public IActionResult Editar(Cliente editarCliente)
        {
            var db = new bdgzContext();
            var miCliente = db.Clientes.Find(editarCliente.Idcliente);
            miCliente.Nombre=editarCliente.Nombre;
            miCliente.Apellido=editarCliente.Apellido;
            miCliente.CC=editarCliente.CC;
            miCliente.Celular=editarCliente.Celular;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var db = new bdgzContext();
            var miCliente = db.Clientes.Find(id);
            return View(miCliente);  
        }






        
        [HttpGet]
        public IActionResult Borrar(int id)
        {
            var db = new bdgzContext();
            var miCliente = db.Clientes.Find(id);
            return View(miCliente);  
        }
        [HttpPost,ActionName("Borrar")]
        public IActionResult ConfirmarBorrar(int id)
        {
            var db = new bdgzContext();
            var miCliente = db.Clientes.Find(id);
            db.Remove(miCliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}