using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Core.IServices
{
    public interface ICartItemService
    {
        IEnumerable<CartItem> GetAllAsQueryable();
        CartItem GetById(Guid id);
        public bool Edit(CartItem cartItem, int quantity);
        public bool Delete(CartItem cartItem);
        public bool Create(CartItem cartItem);
    }
}
