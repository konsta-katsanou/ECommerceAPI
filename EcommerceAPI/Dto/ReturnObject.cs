using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Dto
{
    public class ReturnData<T>
    {

        public T Data { get; set; } // ta data poy tha estelna an uparxei error kai to description

        public int Error { get; set; }

        public string Description { get; set; }

    }
    
    
}
