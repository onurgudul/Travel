using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Results;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByUsername(string username);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetList();
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);

    }
}
