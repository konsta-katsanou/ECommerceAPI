using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAPi.Models;
using EcommerceAPI.Dto;
using EcommerceAPI.SERVICES;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet("info")]
        public string ShowInfo()
        {
            return "Welcome to my first API! ";
        }

        //Http for customers
        [HttpGet("customers")]
        public List<Customer> GetCustomers()
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetCustomers(20);
        }

        [HttpGet("customer/{id}")]
        public ReturnData<Customer> GetCustomerById([FromRoute] int id)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetCustomerById(id);
        }

        [HttpGet("customerByName/{name}")]
        public ReturnData<List<Customer>> GetCustomerByName([FromRoute] string name)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetCustomerByName(name);
        }

        [HttpGet("customer/{id}/{orders}")]
        public ReturnData<List<Order>> GetOrdersByCustomerId([FromRoute] int id)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetOrdersByCustomerId(id);
        }

        [HttpGet("customer/{customerid}/orders/{orderid}")]
        public ReturnData<Order> GetOrderdByOrderId([FromRoute] int customerid, [FromRoute] int orderid)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetOrderdByOrderId(customerid, orderid);
        }



        [HttpPost("customer")]
        public Customer CreateCustomer([FromBody]  CustomerDto customerdto)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.CreateCustomer(customerdto);
        }

        [HttpPut("customer/{customerid}")]

        public ReturnData<Customer> UpdateCustomerById([FromBody] CustomerDto customerdto , [FromRoute] int customerid)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.UpdateCustomerById(customerdto , customerid);
        }

        //Https for Products
        
        [HttpGet("products")]
        public  List<Product> GetProducts( )
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetProducts(20);
        }


        [HttpPost("product")]
        public Product CreateProduct([FromBody] ProductDto productdto)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.CreateProduct(productdto);
        }

        [HttpGet("product/{productid}")]
        public ReturnData<Product> GetProductById([FromRoute] int productid)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetProductById(productid);
        }

        [HttpGet("productByName/{productname}")]
        public ReturnData<List<Product>> GetProductByName([FromRoute] string productname)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.GetProductByName(productname);
        }

        //create an order to a customer


        [HttpPost("customer/{customerid}/order")]
        public Order NewOrderById([FromRoute] int customerid, [FromBody] List<ProductDto> products)
        {
            ECommerceServices cs = new ECommerceServices();
            return cs.NewOrderById(customerid, products);
        }


    }
}
