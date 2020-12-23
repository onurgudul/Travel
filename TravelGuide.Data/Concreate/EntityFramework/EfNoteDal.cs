using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.DataAccess.Concreate;
using TravelGuide.Data.Abstract;
using TravelGuide.Data.Context;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Data.Concreate.EntityFramework
{
    public class EfNoteDal : EfEntityRepositoryBase<Note, DatabaseContext>, INoteDal
    {
        public List<Note> NoteWithAll(Expression<Func<Note, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Note>().Include("Category").Include("Owner").ToList()
                    : context.Set<Note>().Include("Category").Include("Owner").Where(filter).ToList();
            }
        }
    }
}
