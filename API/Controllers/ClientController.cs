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
    [Route("/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _clientService.GetAll()
                );
        }

        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult Get(int id)
        {
            var result = _clientService.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Client model)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest();
            }

            var createdClient = _clientService.Add(model);

            return Ok(createdClient);
        }
        
        public IActionResult Put([FromBody]Client model)
        {
            if (!ModelState.IsValid || model.ClientId == 0)
            {
                return BadRequest();
            }
            var updatedClient = _clientService.Update(model); 

            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = _clientService.Delete(id);

            return Ok(
                    _clientService.Delete(id)
                );
        }

        [Route("/clients/search")]
        [HttpGet]
        public IActionResult Search([FromQuery] string query)
        {
            return Ok(
                _clientService.Search(query)
            );
        }

    }
}
