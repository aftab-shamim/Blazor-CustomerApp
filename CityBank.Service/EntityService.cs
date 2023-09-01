using CityBank.Data;
using CityBank.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityBank.Service
{
    public class EntityService : IEntityService
    {
        private readonly CityBankDbContext _context;
        
        public EntityService(CityBankDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customers>> GetAllCustomer()
        {
            return await _context.Customers.ToListAsync();

            //return await _context.Customers
            // .Include(c => c.AccountsInfo)
            // .ToListAsync();       
        }

        public async Task<Customers> GetByCustomerId(int id)
        {
            return await _context.Customers
            .Include(c => c.AccountsInfo)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
