using FluentValidator;
using FluentValidator.Validation;

namespace ApiDrapper.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address,"Email", "E-mail invalido")
                );
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}