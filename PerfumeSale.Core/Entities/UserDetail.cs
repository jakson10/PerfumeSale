using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Entities
{
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
