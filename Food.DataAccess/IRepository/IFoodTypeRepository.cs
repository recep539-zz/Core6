using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.DataAccess.IRepository
{
    public interface IFoodTypeRepository:IRepository<FoodType>
    {
        void Update(FoodType foodType);
    }
}
