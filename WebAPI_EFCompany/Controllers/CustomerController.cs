using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_EFCompany.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_EFCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// This is the API which will return a list of customers
        /// </summary>
        /// <returns>abrakadabra</returns>
        [HttpGet]
        public string Get()
        {
            string str = "";

            using (Context db = new Context())
            {
                var departments = db.Departments.Include(d=>d.Positions).ToList();

                foreach (var d in departments)
                {
                    foreach(var p in d.Positions)
                    {
                        str += $"Name:{d.Name} PositName:{p.Name}" + Environment.NewLine;
                    }
                    
                    //str += $"name:{p.Name}-count:{p.Positions.Count()}"+ Environment.NewLine;
                }
                return str;//db.Departments.ToList().Select(d=>d.Name);
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
