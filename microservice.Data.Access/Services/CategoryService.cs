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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Category GetById(Guid Id)
        {
            return _unitOfWork.Categories.GetById(Id);
        }
        public IEnumerable<Category> GetAllAsQueryable()
        {
            return _unitOfWork.Categories.GetAllAsQueryable();
        }

        public bool Create(Category category)
        {
            _unitOfWork.Categories.Add(category);
            return _unitOfWork.Commit() > 0;


        }

        public bool Delete(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            return _unitOfWork.Commit() > 0;
        }

        public bool Edit(Category category, string name)
        {
            category.Name = name;
            _unitOfWork.Categories.Update(category);
            return _unitOfWork.Commit() > 0;
        }

    }
}
