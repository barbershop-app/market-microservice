using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Infrastructure.Entities.DB
{
    public class Product
    {
        public Guid Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImageSource { get; set; }


        public virtual Category Category { get; set; }
    }
}
