using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.Entity;
using WebApiEF.Models;

namespace WebApiEF.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController: ControllerBase
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            this._service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserModel user)
        {
            var state = await _service.CreateAsync(user);
            if (state.Code == 200 && state.Data is not null)
            {
                return Ok(state.Data);
            }
            return Ok(state.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var state = await _service.GetAllAsync();
            if (state.Code == 200 && state.Data is not null)
            {
                return Ok(state.Data);
            }
            return Ok(state.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var state = await _service.GetAsync(id);
            if (state.Code == 200 && state.Data is not null)
            {
                return Ok(state.Data);
            }
            return Ok(state.Message);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var state = await _service.DeleteAsync(id);
            if (state.Code == 200 && state.Data is true)
            {
                return Ok(state.Data);
            }
            return Ok(state.Message);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UserModel user)
        {
            var state = await _service.UpdateAsync(id, user);
            if (state.Code == 200 && state.Data is not null)
            {
                return Ok(state.Data);
            }
            return Ok(state.Message);
        }
        
    }
}
