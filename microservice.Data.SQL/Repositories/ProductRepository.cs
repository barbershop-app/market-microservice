using microservice.Core.IRepositories;
using microservice.Infrastructure.Entities.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Data.SQL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private MarketContext? _context { get { return Context as MarketContext; } }
        public ProductRepository(MarketContext context) : base(context)
        {

        }
        public Product GetByIdIncluded(Guid id)
        {
            return _context.Products.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAllAsQueryable(bool track)
        {
            if (track)
                return _context.Products.AsQueryable();

            return _context.Products.AsQueryable().AsNoTracking();
        }
    }
}
