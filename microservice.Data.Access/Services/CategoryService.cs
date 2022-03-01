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
        public Category GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Category> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }

        public bool Create(Category routine)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Category routine)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Category oldRoutine, Category newRoutine)
        {
            throw new NotImplementedException();
        }

    }
}
