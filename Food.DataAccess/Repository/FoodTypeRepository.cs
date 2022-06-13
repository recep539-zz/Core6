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
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        ApplicationDbContext _db;
        public FoodTypeRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(FoodType foodType)
        {
            var objFromDb = _db.FoodTypes.FirstOrDefault(x => x.Id == foodType.Id);
            objFromDb.Name = foodType.Name;           
        }
    }
}
