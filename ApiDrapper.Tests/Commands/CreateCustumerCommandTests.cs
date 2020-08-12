using ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiDrapper.Tests.Commands

{
    [TestClass]
    public class CreateCustumerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Nome";
            command.LastName = "Sobrenome";
            command.Document = "28659170377";
            command.Email = "Email@email.com";
            command.Phone = "991545255";
            
            Assert.AreEqual(true, command.Valid());
        }

        //FAIL GREEN Refactory
    }
}
