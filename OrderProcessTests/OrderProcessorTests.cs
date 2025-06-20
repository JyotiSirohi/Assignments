using Moq;
using NUnit.Framework;
using OrderProcess;
using OrderProcess.Models;
using OrderProcess.Services;

namespace OrderProcessTests
{
    [TestFixture]
    public class OrderProcessorTests
    {
        private Mock<IPackingSlipService> _mockSlipService;
        private Mock<IEmailService> _mockEmailService;
        private Mock<IMembershipService> _mockMembershipService;
        private Mock<ICommissionService> _mockCommissionService;
        private OrderProcessor _processor;

        [SetUp] 
        public void SetUp()
        {
            _mockSlipService = new Mock<IPackingSlipService>();
            _mockEmailService = new Mock<IEmailService>();
            _mockMembershipService = new Mock<IMembershipService>();
            _mockCommissionService = new Mock<ICommissionService>();

            _processor = new OrderProcessor(
                _mockSlipService.Object,
                _mockEmailService.Object,
                _mockMembershipService.Object,
                _mockCommissionService.Object
            );
        }

        [Test]
        public void ProcessPayment_Book_ShouldCallPackingSlipAndCommission()
        {
            var payment = new Payment
            {
                Type = PaymentType.Book,
                ProductName = "Some Book"
            };

            _processor.ProcessPayment(payment);

            _mockSlipService.Verify(p => p.GenerateSlip("Some Book"), Times.Once);
            _mockSlipService.Verify(p => p.GenerateDuplicateSlip("Royalty Department"), Times.Once);
            _mockCommissionService.Verify(c => c.GenerateCommission(), Times.Once);
        }

        [Test]
        public void ProcessPayment_Membership_ShouldActivateAndSendEmail()
        {
            var payment = new Payment
            {
                Type = PaymentType.Membership,
                CustomerEmail = "abc@example.com"
            };

            _processor.ProcessPayment(payment);

            _mockMembershipService.Verify(m => m.ActivateMembership("abc@example.com"), Times.Once);
            _mockEmailService.Verify(e => e.SendEmail("abc@example.com", "Your membership has been activated."), Times.Once);
        }

        [Test]
        public void ProcessPayment_VideoLearningToSki_ShouldAddFreeVideo()
        {
            var payment = new Payment
            {
                Type = PaymentType.Video,
                ProductName = "Learning to Ski"
            };

            _processor.ProcessPayment(payment);

            _mockSlipService.Verify(s => s.GenerateSlip("Learning to Ski"), Times.Once);
            _mockSlipService.Verify(s => s.AddFreeVideo("First Aid"), Times.Once);
        }
    }
}



