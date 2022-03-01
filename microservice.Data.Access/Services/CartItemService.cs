using microservice.Core.IServices;
using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Data.Access.Services
{
    public class CartItemService : ICartItemService
    {
        public CartItem GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<CartItem> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }

        public bool Create(CartItem routine)
        {
            throw new NotImplementedException();
        }

        public bool Delete(CartItem routine)
        {
            throw new NotImplementedException();
        }

        public bool Edit(CartItem oldRoutine, CartItem newRoutine)
        {
            throw new NotImplementedException();
        }

    }
}
