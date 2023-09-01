using System;
using System.Collections.Generic;

namespace CityBank.Models.Domain
{
    public partial class AccountsInfo
    {
        public long AccountNumber { get; set; }
        public decimal? TotalBalance { get; set; }
        public string AccountType { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
