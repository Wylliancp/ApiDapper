using ApiDrapper.Domain.StoreContext.Enums;
using ApiDrapper.Shared.Entities;
using FluentValidator;
using System;

namespace ApiDrapper.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //Se a Data estimada de entrefa for no passado não entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se o Status estiver entregue não pode mais cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}