using CustomerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, Customer customer);
        Task<bool> DeleteAsync(int id);
    }
}
