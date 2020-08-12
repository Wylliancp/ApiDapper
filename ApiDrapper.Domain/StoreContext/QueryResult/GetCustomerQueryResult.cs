using System;

namespace ApiDrapper.Domain.StoreContext.QueryResult
{
    public class GetCustomerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
