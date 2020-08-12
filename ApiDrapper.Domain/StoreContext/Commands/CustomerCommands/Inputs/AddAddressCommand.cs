using ApiDrapper.Domain.StoreContext.Enums;
using ApiDrapper.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;

namespace ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public AddAddressCommand()
        {
        }

        public AddAddressCommand(Guid id, string street, string number, string complement, string district, string city, string state, string country, string zipCode, EAddressType type)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public Guid Id { get; set; }

        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Complement { get;  set; }
        public string District { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
        public EAddressType Type { get;  set; }

        public bool Valid()
        {

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty("ZipCode",ZipCode,"Cep não pode ser Nulo.")
                );
            return IsValid;
        }
        //FailFastValidation
    }
}
