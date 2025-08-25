using CustomerApplication.Interfaces;
using CustomerDomain.Model;
using CustomerInfrastructure.Data;
using CustomerInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Services
{
    public class CustomerService : ICustomerService
    {


        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() => await _context.Customers.ToListAsync();

        public async Task<Customer?> GetByIdAsync(int id) => await _context.Customers.FindAsync(id);

        public async Task<Customer> CreateAsync(Customer customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateAsync(int id, Customer customer)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return null;

            existing.CustomerName = customer.CustomerName;
            existing.CustomerAddress = customer.CustomerAddress;
            existing.ModifiedBy = customer.ModifiedBy;
            existing.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Customers.FindAsync(id);
            if (existing == null) return false;

            _context.Customers.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
