using System;
using System.Collections.Generic;

namespace CityBank.Models.Domain
{
    public partial class Customers
    {
        public Customers()
        {
            AccountsInfo = new HashSet<AccountsInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<AccountsInfo> AccountsInfo { get; set; }
    }
}
