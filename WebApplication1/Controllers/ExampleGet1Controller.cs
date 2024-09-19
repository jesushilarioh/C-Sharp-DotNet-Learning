using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleGet1Controller : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Jesus", "Christina", "Francesca", "Michael"
        };
        // GET: api/<ExampleGet1>
        [HttpGet]
        public IEnumerable<ExampleGet1> Get()
        {
            /*return new string[] { "value1", "value2" };*/
            return Enumerable.Range(1, 3).Select(index => new ExampleGet1
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Name = Names[index],
                Age = Random.Shared.Next(1, 120),
            }).ToArray();
        }

        // GET api/<ExampleGet1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExampleGet1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExampleGet1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExampleGet1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
