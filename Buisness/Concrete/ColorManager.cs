using Buisness.Abstract;
using Buisness.Constants;
using Buisness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;
        public ColorManager(IColorDal brand)
        {
            _color = brand;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
           
            _color.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult< List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _color.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color> (_color.Get(c=>c.ColorId==id));
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
