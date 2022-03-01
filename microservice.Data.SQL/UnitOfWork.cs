using microservice.Core;
using microservice.Core.IRepositories;
using microservice.Data.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Data.SQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketContext _context;
        public UnitOfWork(MarketContext context)
        {
            this._context = context;
        }

        private IProductRepository _productRepository;
        private ICartItemRepository _cartItemRepository;
        private ICategoryRepository _categoryRepository;



        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
        public ICartItemRepository CartItems => _cartItemRepository ??= new CartItemRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);


        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
