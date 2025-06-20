using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Models
{
    public enum PaymentType
    {
        PhysicalProduct,
        Book,
        Membership,
        MembershipUpgrade,
        Video
    }

    public class Payment
    {
        public PaymentType Type { get; set; }
        public string ProductName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
