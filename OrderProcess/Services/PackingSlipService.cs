using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.Services
{
    public class PackingSlipService : IPackingSlipService
    {
        public void GenerateSlip(string product)
        {
            Console.WriteLine($"Packing slip generated for: {product}");
        }

        public void GenerateDuplicateSlip(string department)
        {
            Console.WriteLine($"Duplicate packing slip sent to: {department}");
        }

        public void AddFreeVideo(string video)
        {
            Console.WriteLine($"Added free video: {video} to packing slip");
        }
    }
}
