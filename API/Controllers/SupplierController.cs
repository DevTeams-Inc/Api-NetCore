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

    [Route("/suppliers")]
    public class SupplierController : Controller
    {

        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _supplierService.GetAll()
                );
        }
        
        [HttpGet("{id}", Name = "GetSupplier")]
        public IActionResult Get(int id)
        {
            var result = _supplierService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Supplier model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdSupplier = _supplierService.Add(model);

            return Ok(createdSupplier);
        }
        
        public IActionResult Put([FromBody]Supplier model)
      {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedSupplier = _supplierService.Update(model);
            return Ok(updatedSupplier);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _supplierService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(
                    _supplierService.Delete(id)
                );
        }

        [Route("/suppliers/search")]
        [HttpGet]
        public IActionResult Search([FromQuery] string query)
        {
            return Ok(
                _supplierService.Search(query)
            );
        }
    }
}
