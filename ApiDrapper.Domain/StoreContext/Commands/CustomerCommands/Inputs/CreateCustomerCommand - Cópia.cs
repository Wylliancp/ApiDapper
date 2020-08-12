using ApiDrapper.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public CreateCustomerCommand()
        {
        }

        
        public CreateCustomerCommand(string firstName, string lastName, string document, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve ter no minimo 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O nome deve pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O e-mail é invalido")
                .HasLen(Document, 11,"Document","Cpf Invalido")
                );

            return IsValid;
        }
        //FailFastValidation



    }
}
