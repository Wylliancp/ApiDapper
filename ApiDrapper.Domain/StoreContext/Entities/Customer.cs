using ApiDrapper.Domain.StoreContext.ValueObjects;
using ApiDrapper.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ApiDrapper.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {

        private readonly IList<Address> _addresses;

        public Customer(Name name,
         Document document,
         Email email,
         string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();

        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            //vALIDAR ENDERE�O
            //Adicionar Endere�o
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}