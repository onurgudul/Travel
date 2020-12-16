using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Business.Abstract;
using TravelGuide.Core.Results;
using TravelGuide.Data.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Concreate
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;
        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }
        public IResult Add(Note entity)
        {
            _noteDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Note entity)
        {
            _noteDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Note> GetById(int noteId)
        {
            return new SuccessDataResult<Note>(_noteDal.Get(n => n.Id == noteId));
        }

        public IDataResult<List<Note>> GetList()
        {
            return new SuccessDataResult<List<Note>>(_noteDal.GetList().ToList());
        }

        public IDataResult<List<Note>> NoteWithAll()
        {
            return new SuccessDataResult<List<Note>>(_noteDal.NoteWithAll().ToList());
        }

        public IResult Update(Note entity)
        {
            _noteDal.Update(entity);
            return new SuccessResult();
        }
    }
}
