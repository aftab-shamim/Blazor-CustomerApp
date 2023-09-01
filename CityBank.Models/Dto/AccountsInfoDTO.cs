using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBank.Models.Dto
{
    public class AccountsInfoDTO
    {
        public long AccountNumber { get; set; }
        public decimal? TotalBalance { get; set; }
        public string AccountType { get; set; }
        public int? CustomerId { get; set; }
    }
}
