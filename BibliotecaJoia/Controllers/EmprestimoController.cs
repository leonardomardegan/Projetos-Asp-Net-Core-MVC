using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class EmprestimoController : Controller
    {
        public IActionResult Index()
        {
            string login = (string)TempData["login"];
            return View();
        }
    }
}
