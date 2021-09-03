using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameAPIController : ControllerBase
    {
        Class.Repository<Game> repository = new Class.Repository<Game>();
        [HttpGet]
        public async Task<List<Game>> Get()
        {
            return await repository.ReadAsync();
        }
        // GET api/<CRUDAPIController>/5
        [HttpGet("{name}")]
        public Task<List<Game>> Get(string name)
        {
            return repository.ReadAsync(name);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game x)
        {
            bool s = await repository.CreateASync(x);
            if(s == true)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Game x)
        {
            bool s = await repository.UpdateAsync(x);
            if (s == true)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            Game T = new Game
            {
                Id = id
            };
            return await repository.DelASync(T);
        }
    }
}
