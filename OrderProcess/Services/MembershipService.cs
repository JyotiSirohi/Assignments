using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Services
{
    public class MembershipService : IMembershipService
    {
        public void ActivateMembership(string email)
        {
            Console.WriteLine("Membership activated.");
        }

        public void UpgradeMembership(string email)
        {
            Console.WriteLine("Membership upgraded.");
        }
    }
}
