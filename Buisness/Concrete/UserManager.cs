using Buisness.Abstract;
using Buisness.Constants;
using Buisness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == id));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetail()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.userDetails());
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
