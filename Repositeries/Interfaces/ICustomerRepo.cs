using Ahmed_Mostafa_Saleh_3025305.Data.DTOs;

namespace Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces
{
    public interface ICustomerRepo
    {
        public bool AddCustomer(CustomerRequest customerDTO);
        public CustomerResponse GetCustomerById(int id);
    }
}
