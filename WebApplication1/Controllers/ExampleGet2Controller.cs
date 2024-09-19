using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleGet2Controller : ControllerBase
    {
        // GET: api/<ExampleGet2>
        private static readonly string[] Names = new[]
        {
            "Jesus", 
            "Christina", 
            "Francesca", 
            "Michael"
        };
        private static readonly int[] Ids = new[]
        {
            1, 
            2, 
            3, 
            4
        };
        private static readonly string[] Emails = new[]
        {
            "Jesus@hernandez.com",
            "christina@hernandez.com",
            "Francesca@hernandez.com",
            "michael@hernandez.com"
        };
        private static readonly string[] Dates = new[]
        {
            DateOnly.FromDateTime(DateTime.Now).ToString(), 
            DateOnly.FromDateTime(DateTime.Now).ToString(),
            DateOnly.FromDateTime(DateTime.Now).ToString(), 
            DateOnly.FromDateTime(DateTime.Now).ToString()
        };


        [HttpGet]
        public IEnumerable<ExampleGet2> Get()
        {
            return Enumerable.Range(0, 5).Select(index => new ExampleGet2
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Name = Names[index],
                Id = Ids[index],
                Email = Emails[index]
            });
        }


        // GET api/<ExampleGet2>/5
        [HttpGet("{id}")]
        public ExampleGet2 Get(int id)
        {
            return new ExampleGet2
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
                Name = Names[id],
                Id = Ids[id],
                Email = Emails[id]
            };
        }

        // POST api/<ExampleGet2>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExampleGet2>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExampleGet2>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
