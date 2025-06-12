using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahmed_Mostafa_Saleh_3025305.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [HttpPost]
        public IActionResult AddAccount(AccountRequest accountRequest)
        {
            var result = _accountRepo.AddAccount(accountRequest);
            if(result)
                return Ok();
            return BadRequest("Validation error");
        }
    }
}
