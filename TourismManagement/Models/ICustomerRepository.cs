using System;
using System.Collections.Generic;
using TourismManagement.ViewModels;

namespace TourismManagement.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Gets();
        Customer Get(int id);
        CreateCustomerViewModel Create(CreateCustomerViewModel customer);
        bool Edit(Customer customer);
        bool Delete(int id);
    }
}
