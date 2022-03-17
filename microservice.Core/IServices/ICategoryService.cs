using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Core.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllAsQueryable(bool track);
        Category GetById(int id);
        public bool Delete(Category category);
        public bool Create(Category category);
        bool Update(Category oldCategory, Category category);
    }
}
