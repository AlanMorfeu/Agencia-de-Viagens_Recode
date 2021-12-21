using CrudTripTravel.Models;
using CrudTripTravel.Models.NovaPasta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTripTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context contexto)
        {
            _context = contexto;
        }
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Destinos()
        {
            return View();
        }
        public IActionResult Promocoes()
        {
            return View();
        }
        public IActionResult Contatos()
        {
            return View();
        }

        public IActionResult TBClientes()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult TBClientes(TBClientes cliente)
        {
            _context.clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult TBPromocoes()
        {
            return View("Index");
        }
        public IActionResult TBDestinos()
        {
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
