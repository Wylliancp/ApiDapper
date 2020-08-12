using ApiDrapper.Domain.StoreContext.Entities;
using ApiDrapper.Domain.StoreContext.QueryResult;
using System;
using System.Collections.Generic;

namespace ApiDrapper.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);

    }
}
