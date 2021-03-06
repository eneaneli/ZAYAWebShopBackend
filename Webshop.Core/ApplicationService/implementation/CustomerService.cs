﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Webshop.Core.DomainService;
using Webshop.Core.Entity;

namespace Webshop.Core.ApplicationService.implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        public CustomerService(ICustomerRepository CustomerRepository, IProductRepository ProductRepository)
        {
            _customerRepository = CustomerRepository;
            _productRepository = ProductRepository;
        }

        public Customer AddCustomer(Customer cust)
        {
            
            if (cust.Address == "" || cust.Address == null )
                throw new InvalidDataException("To create a customer you need an address");
            if (cust.Name == "" || cust.Name == null)
                throw new InvalidDataException("To create a customer you need a name");

            var customer = _customerRepository.CreateCustomer(cust);
            if (cust.Products != null) {
                customer.Products = _productRepository.ReadProductByID(customer.Products.Id);
            }
            return customer;
        }

        public Customer DeleteCustomer(Customer cust)
        {
           return _customerRepository.DeleteCustomer(cust);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepository.ReadCustomerById(id);
        }

        public List<Customer> GetCustomers()
        {
           return _customerRepository.ReadCustomers().ToList();
        }

        public Customer UpdateCustomer(Customer cust)
        {

            if (cust.Address == "" || cust.Address == null)
                throw new InvalidDataException("To update a customer you need an address");
            if (cust.Name == "" || cust.Name == null)
                throw new InvalidDataException("To update a customer you need a name");

            var editCust = FindCustomerById(cust.Id);

            editCust.Id = cust.Id;
            editCust.Name = cust.Name;
            editCust.Address = cust.Address;
            editCust.Products = cust.Products;

            return _customerRepository.UpdateCustomer(editCust);
        }
    }
}
