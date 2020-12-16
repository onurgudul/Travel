using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Business.Abstract;
using TravelGuide.Business.Contants;
using TravelGuide.Business.Validation;
using TravelGuide.Core.CrossCutting;
using TravelGuide.Core.Results;
using TravelGuide.Core.Security.Hashing;
using TravelGuide.Entities.Concreate;
using TravelGuide.Entities.Dto;

namespace TravelGuide.Business.Concreate
{
    public class AuthanticationManager : IAuthanticationService
    {
        private readonly IUserService _userService;
        public AuthanticationManager(IUserService userService)
        {
            _userService = userService;
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userCheck = _userService.GetByUsername(userForLoginDto.Username);
            if (userCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userCheck.Data.PasswordHash, userCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userCheck.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            ValidationTool.Validate(new RegisterValidator(), userForRegisterDto);

            byte[] passwordHash, passwordSalt;//CreatePasswordHash methodunda dolacak.
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Name = userForRegisterDto.Name,
                Surname = userForRegisterDto.Surname,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Email = userForRegisterDto.Email,
                Username = userForRegisterDto.Username,
                IsActive = false,
                IsAdmin = false
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegisterd);
        }

        public bool RePasswordControl(UserForRegisterDto userForRegisterDto)
        {
            if (userForRegisterDto.Password != userForRegisterDto.RePassword)
            {
                return false;
            }
            return true;
        }

        public IResult UserExists(string username)
        {
            if (_userService.GetByUsername(username).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
