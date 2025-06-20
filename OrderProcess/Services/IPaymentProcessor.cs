using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderProcess.Models;

namespace OrderProcess.Services
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(Payment payment);
    }
}
