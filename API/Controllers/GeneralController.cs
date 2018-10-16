using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/general")]
    public class GeneralController : Controller
    {
        [Route("/search")]
        public IActionResult Search()
        {
            return Content("hola");
        }
    }
}