using ApiDrapper.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDrapper.Domain.StoreContext.Commands.CustomerCommands.OutPuts
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
