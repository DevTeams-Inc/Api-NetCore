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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _saleService.GetSaleDetail(id)
                );
        }

        [HttpPost]
        public IActionResult Post([FromBody]SaleProductVM  model)
        {
            try
            {
                return Ok(
                   _saleService.Add(model)
                   );
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _saleService.Delete(id)
                );
        }
    }
}
