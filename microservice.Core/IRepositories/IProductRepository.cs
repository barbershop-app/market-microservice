using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Core.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllAsQueryable();
        Product GetByIdIncluded(Guid id);
    }
}
