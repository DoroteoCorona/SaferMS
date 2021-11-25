using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaferMS.Controllers
{
    public class InicioUsuarioSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InicioUsuarioS()
        {
            return View();
        }
    }


}