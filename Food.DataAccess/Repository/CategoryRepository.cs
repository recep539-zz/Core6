using Food.DataAccess.Data;
using Food.DataAccess.IRepository;
using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(x => x.Id == category.Id);
            objFromDb.Name = category.Name; 
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
