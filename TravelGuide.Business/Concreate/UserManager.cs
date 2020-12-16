using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Business.Abstract;
using TravelGuide.Business.Validation;
using TravelGuide.Core.CrossCutting;
using TravelGuide.Core.Results;
using TravelGuide.Data.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Concreate
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User entity)
        {
            ValidationTool.Validate(new UserValidator(), entity);
            _userDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<User> GetByUsername(string username)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Username == username));
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();
        }
    }
}
