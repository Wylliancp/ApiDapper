using ApiDrapper.Domain.StoreContext.Entities;
using ApiDrapper.Domain.StoreContext.Enums;
using ApiDrapper.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace ApiDrapper.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {//Red Green Validation

        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        public OrderTests()
        {
            var name = new Name("wyllian", "costa");
            var document = new Document("77249471040");
            var email = new Email("wyllian@gmail.com");
            _customer = new Customer(name, document, email, "556191164858");
            _order = new Order(_customer);
            
            _mouse = new Product("Mouse", "Mouse Gamer", "mouse.png", 10M, 10);
            _keyboard = new Product("KeyBoard", "Keyboard Ganer", "KeyBoard.png", 20M, 10);
            _chair = new Product("Chair", "Chair Gamer", "Chair.png", 60M, 10);
            _monitor = new Product("Monitor", "Monitor Curvado", "Monitor.png", 90M, 10);
        }

        //Consigo criar um Pedido
        [TestMethod]
        public void ShouldCreatedOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        //Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatuShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }
        //Ao adicionar um novo item, a quantidade deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_mouse, 2);
            _order.AddItem(_monitor, 2);

            Assert.AreEqual(2, _order.Items.Count);
        }
        // Ao adicionar um novo item, deve subtair a quantidade do produto
        [TestMethod]
        public void ShouldResturnsFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(_mouse.QuantityOnHand, 5);

        }
        // Ao confirmar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }
        // Ao pagar um pedido, o status deve ser pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreNotEqual("",_order.Status);
        }
        // Dados mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {

            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void StatusShouldShippingsWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            _order.Cancel();
            foreach(var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}
