using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;

namespace Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces
{
    public interface IBranchRepo
    {
        public bool AddBranch(BranchWithCustomer branchDTO);
        public List<BranchWithCustomerResponse> GetBranches();
        public bool UpdateBranch(int id, UpdateBranchWithCustomer branchDTO);
        public bool DeleteBranch(int id);
    }
}
