using CityBank.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBank.Models.Dto;

namespace CityBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IEntityService _service;
        public CustomersController(IEntityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customers = await _service.GetAllCustomer();

            var customerDTOs = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
            }).ToList();
            return customerDTOs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _service.GetByCustomerId(id);

            if (customer == null)
                return NotFound();

            var customerDTOs = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                AccountsInfoDTO = customer.AccountsInfo.Select(accountInfo => new AccountsInfoDTO
                {
                    AccountNumber = accountInfo.AccountNumber,
                    AccountType = accountInfo.AccountType,
                    TotalBalance = accountInfo.TotalBalance,
                    CustomerId = accountInfo.CustomerId
                }).ToList()
            };
            return customerDTOs;
        }
    }
}
