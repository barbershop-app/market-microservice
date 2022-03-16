using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Core.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllAsQueryable();
        Product GetById(Guid id);
        public bool Edit(Product oldProduct, Product newProduct);
        public bool Delete(Product product);
        public bool Create(Product product);
    }
}
