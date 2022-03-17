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
        public Product GetById(Guid Id)
        {
            return _unitOfWork.Products.GetByIdIncluded(Id);
        }
        public IEnumerable<Product> GetAllAsQueryable(bool track)
        {
            return _unitOfWork.Products.GetAllAsQueryable(track);
        }


        public bool Create(Product product)
        {
            _unitOfWork.Products.Add(product);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(Product product)
        {
            _unitOfWork.Products.Remove(product);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(Product oldProduct, Product newProduct)
        {
            oldProduct.CategoryId = newProduct.CategoryId;
            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;

            if(newProduct.ImageSource != null)
             oldProduct.ImageSource = newProduct.ImageSource;


            _unitOfWork.Products.Update(oldProduct);
            return _unitOfWork.Commit() > 0;
        }

    }
}
