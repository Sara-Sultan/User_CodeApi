using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDTO
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
