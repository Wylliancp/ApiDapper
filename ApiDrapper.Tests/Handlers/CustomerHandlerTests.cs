using ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using ApiDrapper.Domain.StoreContext.Handlers;
using ApiDrapper.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiDrapper.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {

        [TestMethod]
        public void SouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Nome";
            command.LastName = "Sobrenome";
            command.Document = "28659170377";
            command.Email = "Email@email.com";
            command.Phone = "991545255";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handler(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(0, handler.IsValid);
        }

    }
}
