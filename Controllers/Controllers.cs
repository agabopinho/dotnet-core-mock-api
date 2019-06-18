using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mock_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> Get()
        {
            return GetCustomers().ToArray();
        }

        private IEnumerable<CustomerModel> GetCustomers()
        {
            yield return new CustomerModel(1, "C", "A");
            yield return new CustomerModel(2, "C", "B");
            yield return new CustomerModel(3, "C", "C");
        }
        
        ///
        /// 
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = GetCustomers().FirstOrDefault(i => i.Id == id);
            return customer != null ? Ok(customer) as ActionResult : NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CustomerModel value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerModel value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class CustomerModel
    {
        public CustomerModel(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
