using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Infrastructure.Entities.DTOs
{
    public class ProductDTOs
    {
        public class Create
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Descreption { get; set; }
            public double Price { get; set; }
            public bool IsAvailable { get; set; }
            public bool OnSale { get; set; }
            public int? OnSalePercentage { get; set; }
            public string? ImageSource { get; set; }

        }


        public class Update : Create
        {
            public Guid Id { get; set; }
        }
    }
}
