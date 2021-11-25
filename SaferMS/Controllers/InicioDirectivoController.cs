using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaferMS.Controllers
{
    public class InicioDirectivoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InicioDirectivo()
        {
            return View();
        }
    }


}