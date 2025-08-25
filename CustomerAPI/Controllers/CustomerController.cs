using CustomerApplication.Interfaces;
using CustomerApplication.Services;
using CustomerDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(new
            {
                message = "Data retrieved",
                transactionId = Guid.NewGuid(),
                data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(new { message = "Not found", transactionId = Guid.NewGuid() });

            return Ok(new
            {
                message = "Data found",
                transactionId = Guid.NewGuid(),
                data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            var created = await _service.CreateAsync(customer);
            return Ok(new
            {
                message = "Customer created",
                transactionId = Guid.NewGuid(),
                data = created
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            var updated = await _service.UpdateAsync(id, customer);
            if (updated == null) return NotFound(new { message = "Not found", transactionId = Guid.NewGuid() });

            return Ok(new
            {
                message = "Customer updated",
                transactionId = Guid.NewGuid(),
                data = updated
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = "Not found", transactionId = Guid.NewGuid() });

            return Ok(new
            {
                message = "Customer deleted",
                transactionId = Guid.NewGuid()
            });


        }
    }
}
