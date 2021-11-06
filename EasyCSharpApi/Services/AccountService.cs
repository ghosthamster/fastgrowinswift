using AutoMapper;
using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;
using EasyCSharpApi.Services.Abstractions;
using EasyCSharpApi.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _unitOfWork.AccountRepository.GetById(id);
            var mappedUser = _mapper.Map<User, UserDTO>(user);

            return mappedUser;
        }

        public int? Login(UserDTO user)
        {
            var mappedUser = _mapper.Map<UserDTO, User>(user);
            var result = _unitOfWork.AccountRepository.Authenticate(mappedUser);

            return result;
        }

        public int? Register(UserDTO user)
        {
            var mappedUser = _mapper.Map<UserDTO, User>(user);
            mappedUser.DateOfRegister = DateTime.Now;
            var userId = _unitOfWork.AccountRepository.Authenticate(mappedUser);
            if (userId == null)
            {
                var result = _unitOfWork.AccountRepository.Add(mappedUser);
                _unitOfWork.Save();

                return result.Id;
            }
            else
                throw new ArgumentException("This user already registred");
        }
    }
}
