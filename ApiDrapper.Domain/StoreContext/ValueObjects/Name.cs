using FluentValidator;
using FluentValidator.Validation;

namespace ApiDrapper.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string fisrtName, 
            string lastName)
        {
            FisrtName = fisrtName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FisrtName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FisrtName, 40, "FirstName", "O nome deve conter no maxino 40 caracteres")
                .HasMinLen(lastName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(lastName, 40, "FirstName", "O nome deve conter no maxino 40 caracteres")
                );
        }

        public string FisrtName { get; private set; }
        public string LastName { get; private set; }


        public override string ToString()
        {
            return $"{FisrtName} {LastName}";
        }
    }
}