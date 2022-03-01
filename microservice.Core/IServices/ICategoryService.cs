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
        public bool Edit(Category oldRoutine, Category newRoutine);
        public bool Delete(Category routine);
        public bool Create(Category routine);
    }
}
