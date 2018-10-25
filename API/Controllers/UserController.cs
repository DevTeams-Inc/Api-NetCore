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
    [Route("/users")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                    _userService.GetAll()
                );
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            var result = _userService.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdUser = _userService.Add(model);

            return Ok(createdUser);
        }

        public IActionResult Put([FromBody]User model)
        {
            if (!ModelState.IsValid || model.UserId == 0)
            {
                return BadRequest();
            }
            var updatedUser = _userService.Update(model);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(
                    _userService.Delete(id)
                );
            } 
        }

        [Route("/users/search")]
        [HttpGet]
        public IActionResult Search([FromQuery] string query)
        {
            return Ok(
                _userService.Search(query)
            );
        }
    }
}
