using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Infrastructure.Entities.DB
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string? ImageSource { get; set; }


    }
}
