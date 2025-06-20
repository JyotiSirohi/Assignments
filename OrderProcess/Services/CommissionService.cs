using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Services
{
    public class CommissionService : ICommissionService
    {
        public void GenerateCommission()
        {
            Console.WriteLine("Commission payment generated for agent.");
        }
    }
}
