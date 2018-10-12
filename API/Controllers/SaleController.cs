using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.VM;
using Service.IServices;

namespace API.Controllers
{
    [Route("/sales")]
    public class SaleController : Controller
    {

        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _saleService.GetAll()
                );
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        //revisar error del Json
        [HttpPost]
        public IActionResult Post([FromBody]SaleProductVM  model)
        {


            try
            {
                return Ok(
                   _saleService.Add(model)
                   );
            }
            catch (Exception e)
            {
                Console.WriteLine("este error :" + e.Message);
                return BadRequest();

            }


            //if (ModelState.IsValid)
            //{
               
            //}
            //else
            //{
            //}
        }
 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
