using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.IServices;

namespace API.Controllers
{
    [Route("/products")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _productService.GetAll()
                );
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            var result = _productService.Get(id);

            if (result.Equals(null))
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product model)
        {
            if (model.Equals(null))
            {
                return BadRequest();
            }

            var createdProduct = _productService.Add(model);

            return Ok(createdProduct);
        }


        public IActionResult Put([FromBody]Product model)
        {
            if (model.Equals(null) || model.ProductId.Equals(0))
            {
                return BadRequest();
            }

            var updatedProduct = _productService.Update(model);

            return Ok(updatedProduct);
        }
 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Get(id);

            if (result.Equals(null))
            {
                return NotFound();
            }
            else
            {
                return Ok(
                    _productService.Delete(id)
                );
            }
        }
    }
}
