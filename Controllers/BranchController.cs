using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahmed_Mostafa_Saleh_3025305.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepo _branchRepo;

        public BranchController(IBranchRepo branchRepo)
        {
            _branchRepo = branchRepo;
        }
        [HttpPost]
        public IActionResult AddBranch(BranchWithCustomer branchDTO)
        {
            var result = _branchRepo.AddBranch(branchDTO);
            if (result)
                return Ok();
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetBranches()
        {
            var result = _branchRepo.GetBranches();
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBranch(int id, UpdateBranchWithCustomer branchDTO)
        {
            var result = _branchRepo.UpdateBranch(id, branchDTO);
            return result ? Ok() : NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBranch(int id)
        {
            var result = _branchRepo.DeleteBranch(id);
            return result ? Ok() : NotFound();
        }
    }
}
