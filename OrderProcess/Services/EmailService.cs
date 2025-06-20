using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"Email sent to {email}: {message}");
        }
    }
}
