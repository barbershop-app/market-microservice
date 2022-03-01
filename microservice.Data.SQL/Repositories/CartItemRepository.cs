using microservice.Core.IRepositories;
using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Data.SQL.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private MarketContext? _context { get { return Context as MarketContext; } }
        public CartItemRepository(MarketContext context) : base(context)
        {

        }
        public CartItem GetByIdIncluded(Guid id)
        {
            return _context.CartItems.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<CartItem> GetAllAsQueryable()
        {
            return _context.CartItems.AsQueryable();
        }
    }
}
