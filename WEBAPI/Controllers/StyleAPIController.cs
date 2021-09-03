using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleAPIController : ControllerBase
    {
        Class.Repository<StyleFoGame> repository = new Class.Repository<StyleFoGame>();

        [HttpGet]
        public async Task<List<StyleFoGame>> Get()
        {
            return await repository.ReadAsync();
        }
        // GET api/<CRUDAPIController>/5
        
        // POST api/<CRUDAPIController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StyleFoGame x)
        {
            bool s = await repository.CreateASync(x);
            if (s == true)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        // PUT api/<CRUDAPIController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StyleFoGame x)
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

        // DELETE api/<CRUDAPIController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            StyleFoGame T = new StyleFoGame
            {
                Id = id
            };
            return await repository.DelASync(T);
        }

    }
}
