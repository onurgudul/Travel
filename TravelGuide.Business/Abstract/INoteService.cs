using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Results;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Abstract
{
    public interface INoteService
    {
        IDataResult<List<Note>> NoteWithAll();
        IDataResult<Note> GetById(int noteId);
        IDataResult<List<Note>> GetList();
        IResult Add(Note entity);
        IResult Update(Note entity);
        IResult Delete(Note entity);
    }
}
