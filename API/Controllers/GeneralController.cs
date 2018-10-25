using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace API.Controllers
{
    [Route("/general")]
    public class GeneralController : Controller
    {
        private IProductService _productService;
        public GeneralController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("/noting")]
        public IActionResult Search()
        {
            return Content("hola");
        }

        [Route("/products/sold-out")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _productService.ExistenceOfProducts()
                );
        }


    }
}