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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Product GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Product> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }


        public bool Create(Product routine)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product routine)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Product oldRoutine, Product newRoutine)
        {
            throw new NotImplementedException();
        }

    }
}
