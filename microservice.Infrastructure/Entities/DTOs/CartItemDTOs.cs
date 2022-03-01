using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Infrastructure.Entities.DTOs
{
    public class CartItemDTOs
    {
        public class Create
        {
            public Guid UserId { get; set; }
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }


        public class Update : Create
        {
            public Guid Id { get; set; }
        }




    }
}
