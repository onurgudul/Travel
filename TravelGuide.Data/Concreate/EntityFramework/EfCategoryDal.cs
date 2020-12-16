using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.DataAccess.Concreate;
using TravelGuide.Data.Abstract;
using TravelGuide.Data.Context;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Data.Concreate.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,DatabaseContext>,ICategoryDal
    {
    }
}
