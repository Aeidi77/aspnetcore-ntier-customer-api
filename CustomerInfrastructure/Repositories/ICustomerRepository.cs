using CustomerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfrastructure.Repositories
{
    public interface ICustomerRepository
    {
       Task<List<Customer>> GetAll();   
        Task<Customer?> GetById(int id);
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task Delete(int id);

    }

  
}
