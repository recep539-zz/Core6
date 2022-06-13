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
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(MenuItem obj)
        {
            var objFromDb = _db.MenuItems.FirstOrDefault(x => x.Id == obj.Id);
            objFromDb.Name = obj.Name;
            objFromDb.Description = obj.Description;
            objFromDb.Price = obj.Price;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.FoodTypeId = obj.FoodTypeId;
            if (objFromDb.Image != null)
            {
                objFromDb.Image = obj.Image;
            }
        }
    }
}
