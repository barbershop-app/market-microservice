using microservice.Core.IRepositories;
using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Data.SQL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private MarketContext? _context { get { return Context as MarketContext; } }
        public CategoryRepository(MarketContext context) : base(context)
        {

        }
        public Category GetByIdIncluded(int id)
        {
            return _context.Categories.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Category> GetAllAsQueryable()
        {
            return _context.Categories.AsQueryable();
        }

    }
}
