using microservice.Core;
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
        private readonly IUnitOfWork _unitOfWork;
        public CartItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CartItem GetById(Guid Id)
        {
            return _unitOfWork.CartItems.GetById(Id);
        }
        public IEnumerable<CartItem> GetAllAsQueryable(bool track)
        {
            return _unitOfWork.CartItems.GetAllAsQueryable(track);
        }

        public bool Create(CartItem cartItem)
        {
            _unitOfWork.CartItems.Add(cartItem);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(CartItem cartItem)
        {
            _unitOfWork.CartItems.Remove(cartItem);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(CartItem oldCartItem, CartItem cartItem)
        {
            oldCartItem.Quantity = cartItem.Quantity;
            _unitOfWork.CartItems.Update(cartItem);
            return _unitOfWork.Commit() > 0;
        }
    }
}
