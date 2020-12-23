using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.DataAccess.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Data.Abstract
{
    public interface INoteDal : IEntityRepository<Note>
    {
        List<Note> NoteWithAll(Expression<Func<Note, bool>> filter = null);
    }
}
