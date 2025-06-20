using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPackingSlipService
{
    void GenerateSlip(string productName);
    void GenerateDuplicateSlip(string department);
    void AddFreeVideo(string videoName);
}

public interface IEmailService
{
    void SendEmail(string to, string message);
}

public interface IMembershipService
{
    void ActivateMembership(string email);
    void UpgradeMembership(string email);
}

public interface ICommissionService
{
    void GenerateCommission();
}
