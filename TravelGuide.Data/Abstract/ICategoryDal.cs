using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.DataAccess.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Data.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
