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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private MarketContext? _context { get { return Context as MarketContext; } }
        public CategoryRepository(MarketContext context) : base(context)
        {

        }
        public Category GetById(int id)
        {
            return _context.Categories.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Category> GetAllAsQueryable(bool track)
        {
            if (track)
                return _context.Categories.AsQueryable();

            return _context.Categories.AsQueryable().AsNoTracking();
        }

    }
}
