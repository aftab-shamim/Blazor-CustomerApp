using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBank.Models.Dto
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public List<AccountsInfoDTO> AccountsInfoDTO  { get; set; }
        
    }
}
