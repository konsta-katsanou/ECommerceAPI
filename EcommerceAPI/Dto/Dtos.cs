using System;
namespace EcommerceAPI.Dto
{

    public class CustomerDto
    {
       
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public decimal Balance { get; set; }
        

    }

    public class ProductDto
    {
        
        public string Name { get; set; }
        
        public int OrderQuantity { get; set; }

        public  decimal Price { get; set; }


        

        

    }
}
