using microservice.Infrastructure.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microservice.Core.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public IEnumerable<Category> GetAllAsQueryable(bool track);
        Category GetById(int id);
    }
}
