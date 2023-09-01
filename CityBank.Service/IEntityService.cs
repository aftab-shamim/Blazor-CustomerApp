using CityBank.Data;
using CityBank.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityBank.Service
{
    public interface IEntityService
    {
        Task<Customers> GetByCustomerId(int id);
        Task<IEnumerable<Customers>> GetAllCustomer();
    }
}
