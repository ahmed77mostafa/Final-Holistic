using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahmed_Mostafa_Saleh_3025305.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRequest customerDTO)
        {
            var result = _customerRepo.AddCustomer(customerDTO);
            if (result)
                return Ok();
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerRepo.GetCustomerById(id);
            if(result != null)
                return Ok(result);
            else
                return NotFound($"Id: {id} not found");
        }
    }
}
