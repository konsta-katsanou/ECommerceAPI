using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceAPI.Dto;
using EcommerceAPi.Models;

namespace EcommerceAPI.SERVICES
{
    public class ECommerceServices
    {


        public List<Customer> GetCustomers(int howMany)
        {
            List<Customer> Customers;



            using (EcommerceDbContent college = new EcommerceDbContent())
            {
                Customers = college.Customers
                    .Take(howMany)
                    .ToList();

                return Customers;

            }


        }



        public ReturnData<Customer> GetCustomerById(int customerId)
        {
            using (EcommerceDbContent college = new EcommerceDbContent())
            {
                Customer customer = college.Customers.Find(customerId);

                return new ReturnData<Customer>
                {
                    Data = customer,
                    Error = (customer == null) ? 1 : 0,
                    Description = (customer == null) ? "no such student id " : "ok"

                };
            }
        }



        public ReturnData<List<Customer>> GetCustomerByName(string customerName)
        {
            using (EcommerceDbContent college = new EcommerceDbContent())
            {
                List<Customer> customers = college.Customers.Where(s => s.Name.
                                               Contains(customerName,
                                               StringComparison.OrdinalIgnoreCase)).
                                               ToList();

                return new ReturnData<List<Customer>>

                {
                    Data = customers,
                    Error = (customers == null) ? 1 : 0,
                    Description = (customers == null) ? "no such student " : "ok"
                };
            }
        }


        public ReturnData<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            using (EcommerceDbContent college = new EcommerceDbContent())
            {
                List<Order> orders = college.Orders.Where(o => o.CustomerId == customerId).ToList();

                return new ReturnData<List<Order>>

                {
                    Data = orders,
                    Error = (orders == null) ? 1 : 0,
                    Description = (orders == null) ? "the customer has no orders " : "ok"
                };
            }
        }


        public ReturnData<Order> GetOrderdByOrderId(int customerId, int orderId)
        {
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                Customer customer = db.Customers.Find(customerId);

                if (customer == null)
                {
                    return new ReturnData<Order>
                    {
                        Error = 1 ,
                        Description = "there is no such customer"
                    };

                }

                List<Order> orders =db.Orders.Where(o => o.CustomerId == customerId).ToList();

                Order order = db.Orders.Find(orderId);

                return new ReturnData<Order>

                {
                    Data = order,
                    Error = (order == null) ? 1 : 0,
                    Description = (order == null) ? "there is no such order " : "ok"
                };
            }
        }




        public Customer CreateCustomer(CustomerDto customerdto)
        {

            Customer c = new Customer()
            {
                Name = customerdto.Name,
                Address = customerdto.Address,
                Balance = customerdto.Balance,
                RegistrationDate = customerdto.RegistrationDate
            };
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                db.Customers.Add(c);
                db.SaveChanges();
            }
            return c;

        }


        public ReturnData<Customer> UpdateCustomerById(CustomerDto customerdto, int customerid)
        {
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                Customer updatedcustomer = db.Customers.Find(customerid);

                if (customerdto.Name != null)
                {
                    updatedcustomer.Name = customerdto.Name;
                }

                if (customerdto.Address != null)
                {
                    updatedcustomer.Address = customerdto.Address;
                }

                if (customerdto.Balance != 0)
                {
                    updatedcustomer.Balance = customerdto.Balance;
                }
                if (customerdto.RegistrationDate != null)
                {
                    updatedcustomer.RegistrationDate = customerdto.RegistrationDate;
                }

                db.SaveChanges();

                return new ReturnData<Customer>
                {
                    Data = updatedcustomer,
                    Error = (updatedcustomer == null) ? 1 : 0,
                    Description = (updatedcustomer == null) ? "there is no such customer" : "OK"

                };

            }


        }




        /* Services  for Products*/

        public List<Product> GetProducts(int howMany)
        {
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                List<Product> products = db.Products.Take(howMany).ToList();

                return products;

            }

        }


        public Product CreateProduct(ProductDto productdto)
        {
            Product p = new Product();

            p.Name = productdto.Name;
            p.Price = productdto.Price;
            p.StockQuantity = productdto.OrderQuantity;
            
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
            return p;
        }




        public ReturnData<Product> GetProductById(int productid)
        {
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                Product p = db.Products.Find(productid);

                return new ReturnData<Product>
                {
                    Data = p,
                    Error = (p == null) ? 1 : 0,
                    Description = (p == null) ? "there is no such product" : "Ok"
                };
            }
        }


        public ReturnData<List<Product>> GetProductByName(string productname)
        {
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                List<Product> products = db.Products.Where(p => p.Name.Contains
                                                            (productname,
                                                            StringComparison.OrdinalIgnoreCase)).
                                                            ToList();

                return new ReturnData<List<Product>>
                {
                    Data = products,
                    Error = (products == null) ? 1 : 0,
                    Description = (products == null) ? "there are no such product " : "Ok"
                };
            }
        }



        


        public Order NewOrderById(int customerid, List<ProductDto> products)
        {
            
            using (EcommerceDbContent db = new EcommerceDbContent())
            {
                Customer c = db.Customers.Find(customerid);

                Order order = new Order() {

                    Customer = c,

                    CustomerId = customerid,

                    Date = DateTime.Now 
                    
                };
                
                
                List<OrderProduct> orderProducts = new List<OrderProduct>();

                foreach (var product in products)
                {

                    Product orderedProduct = db.Products.Where(p => p.Name.Equals(
                                                              product.Name,
                                                              StringComparison.OrdinalIgnoreCase))
                                                              .First();
                                                             

                    OrderProduct orderedproducts = new OrderProduct()
                    {
                        Product = orderedProduct,
                        OrderQuantity = product.OrderQuantity,
                        OrderId= order.Id , 
                        ProductId = orderedProduct.Id
                        

                    };

                    orderProducts.Add(orderedproducts);
                    db.OrderProducts.Add(orderedproducts);
                }

                
                order.OrderProduct = orderProducts;
                
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
        }
    }
}
            