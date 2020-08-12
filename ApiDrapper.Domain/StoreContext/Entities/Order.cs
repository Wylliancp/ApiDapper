using ApiDrapper.Domain.StoreContext.Enums;
using ApiDrapper.Shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ApiDrapper.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();//IREADONLYCOLLECTION, não funciona para alguns ORM -
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        //public void AddItem(OrderItem item)
        //{
        //    //Valida Item
        //    //Adiciona ao Pedido
        //    _items.Add(item);
        //}
        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque");

            var item = new OrderItem(product, quantity);
            //AddItem(item);
            _items.Add(item);
        }
        //public void AddDelivery(Delivery delivery)
        //{
        //    //Valida Delivery
        //    //Adiciona ao Delivery
        //    _deliveries.Add(delivery);
        //}

        //To Place an Order
        //Criar um Pedido
        public void Place()
        {
            //Validar
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "Este Pedido não possui Itens");
        }

        //Pagar um Pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //Enviar um pedido
        public void Ship()
        {
            // A cada 5 produtos é uma entrega 
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));

            var count = 1;
            //Quebra as Entregas
            foreach (var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            //Envia todas as entregas
            deliveries.ToList().ForEach(x => x.Ship());
            //Adiciona as entregas ao pedido
            deliveries.ToList().ForEach(x => _deliveries.Add(x));
        }
        //Cancelar um Pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}