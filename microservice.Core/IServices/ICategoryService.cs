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
        IEnumerable<Category> GetAllAsQueryable();
        Category GetById(Guid id);
        public bool Edit(Category category, string name);
        public bool Delete(Category category);
        public bool Create(Category category);
    }
}
