using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TourismManagement.ViewModels;

namespace TourismManagement.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CreateCustomerViewModel Create(CreateCustomerViewModel customer)
        {
            var newCus = new Customer()
            {
                FullName = customer.FullName,
                Departure = customer.Departure,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                IdentityCard = customer.IdentityCard
            };
                context.Customers.Add(newCus);
                context.SaveChanges();
            if(customer.Tours != null)
            {
                var ctList = new List<CustomerTour>();
                ctList = customer.Tours.Select(t => new CustomerTour()
                {
                    TourId = t,
                    CustomerId = newCus.CustomerId
                }).ToList();
                if(ctList != null && ctList.Any())
                {
                    context.CustomerTours.AddRange(ctList);
                    context.SaveChanges();
                }               
            }
            customer.CustomerId = newCus.CustomerId;
                return customer;
                        
        }

        public bool Delete(int id)
        {
            var delCus = context.Customers.Find(id);
            
            if (delCus != null)
            {
                List<CustomerTour> ctList = (from ct in context.CustomerTours
                                             where ct.CustomerId == delCus.CustomerId
                                             select ct).ToList();
                context.CustomerTours.RemoveRange(ctList);
                context.SaveChanges();
                context.Remove(delCus);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Edit(Customer customer)
        {
            try
            {
                var editCus = context.Customers.Attach(customer);
                editCus.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public IEnumerable<Customer> Gets()
        {
            var customers = new List<Customer>();
            customers = context.Customers.ToList();
            if(customers != null && customers.Any())
            {
                foreach (var cust in customers)
                {
                    cust.Tours = string.Join(", ", (from t in context.Tours
                                                    join ct in context.CustomerTours
                                                      on t.TourId equals ct.TourId
                                                    where ct.CustomerId == cust.CustomerId
                                                    select t.TourName).ToList());
                }
            }
            
            return customers;
        }
    }
}
