using ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.OutPuts;
using ApiDrapper.Domain.StoreContext.Entities;
using ApiDrapper.Domain.StoreContext.Repositories;
using ApiDrapper.Domain.StoreContext.Services;
using ApiDrapper.Domain.StoreContext.ValueObjects;
using ApiDrapper.Shared.Commands;
using FluentValidator;
using System;

namespace ApiDrapper.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly IEmailService _emailService;
        private ICustomerRepository _repository;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;

        }

        public ICommandResult Handler(CreateCustomerCommand command)
        {
            //Verificar se cpf já existe 
            var checkDocument =_repository.CheckDocument(command.Document);
            if (checkDocument)
                AddNotification("Document", "Este CPF já esta em uso");
            //verificar se existe e-mail cadastrado
            var checkEmail = _repository.CheckEmail(command.Email);
            if (checkEmail)
                AddNotification("E-mail", "Este e-mail já esta em uso");
            //Criar VOS
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            //Criar Entidades
            var customer = new Customer(name, document, email, command.Phone);

            //validar VOS E Entidades

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false,
                                        "Requisição com erros",
                                        new { Id = customer.Id, 
                                              Name = customer.Name.ToString(), 
                                              Email = email.Address});

            //Persistir 
            _repository.Save(customer);

            //Enviar e-mail
            _emailService.Send(email.Address,"Hello@gmail.com","Bem vindo","Sejá bem vindo " + customer.Name);

            //retorna valores
            return new CommandResult(true, "Bem vindo", email.Address);
        }   

        public ICommandResult Handler(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
