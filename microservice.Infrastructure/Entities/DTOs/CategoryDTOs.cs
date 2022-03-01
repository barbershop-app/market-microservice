using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Infrastructure.Entities.DTOs
{
    public class CategoryDTOs
    {
        public class Create
        {
            public string Name { get; set; }

        }

        public class Update : Create
        {
            public int Id { get; set; } 
        }
    }
}
