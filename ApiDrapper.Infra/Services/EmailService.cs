using ApiDrapper.Domain.StoreContext.Services;
using System;

namespace ApiDrapper.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            //
        }
    }
}
