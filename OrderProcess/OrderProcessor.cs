using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcess.Models;
using OrderProcess.Services;

namespace OrderProcess
{
    public class OrderProcessor : IPaymentProcessor
    {
        private readonly IPackingSlipService _packingSlipService;
        private readonly IEmailService _emailService;
        private readonly IMembershipService _membershipService;
        private readonly ICommissionService _commissionService;

        public OrderProcessor(
        IPackingSlipService packingSlipService,
        IEmailService emailService,
        IMembershipService membershipService,
        ICommissionService commissionService)
        {
            _packingSlipService = packingSlipService;
            _emailService = emailService;
            _membershipService = membershipService;
            _commissionService = commissionService;
        }

        public void ProcessPayment(Payment payment)
        {
            switch (payment.Type)
            {
                case PaymentType.PhysicalProduct:
                    _packingSlipService.GenerateSlip(payment.ProductName);
                    _commissionService.GenerateCommission();
                    break;

                case PaymentType.Book:
                    _packingSlipService.GenerateSlip(payment.ProductName);
                    _packingSlipService.GenerateDuplicateSlip("Royalty Department");
                    _commissionService.GenerateCommission();
                    break;

                case PaymentType.Membership:
                    _membershipService.ActivateMembership(payment.CustomerEmail);
                    _emailService.SendEmail(payment.CustomerEmail, "Your membership has been activated.");
                    break;

                case PaymentType.MembershipUpgrade:
                    _membershipService.UpgradeMembership(payment.CustomerEmail);
                    _emailService.SendEmail(payment.CustomerEmail, "Your membership has been upgraded.");
                    break;

                case PaymentType.Video:
                    _packingSlipService.GenerateSlip(payment.ProductName);
                    if (payment.ProductName == "Learning to Ski")
                    {
                        _packingSlipService.AddFreeVideo("First Aid");
                    }
                    break;
            }
        }
    }
}
