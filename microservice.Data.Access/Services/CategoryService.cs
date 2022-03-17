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
        public Category GetById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }
        public IEnumerable<Category> GetAllAsQueryable(bool track)
        {
            return _unitOfWork.Categories.GetAllAsQueryable(track);
        }

        public bool Create(Category category)
        {
            _unitOfWork.Categories.Add(category);
            return _unitOfWork.Commit() > 0;


        }
        public bool Update(Category oldCategory, Category category)
        {
            oldCategory.Name = category.Name;
            _unitOfWork.Categories.Update(oldCategory);

            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            return _unitOfWork.Commit() > 0;
        }


    }
}
