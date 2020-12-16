using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Results;
using TravelGuide.Entities.Concreate;
using TravelGuide.Entities.Dto;

namespace TravelGuide.Business.Abstract
{
    public interface IAuthanticationService
    {
        IResult UserExists(string username);
        bool RePasswordControl(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

    }
}
