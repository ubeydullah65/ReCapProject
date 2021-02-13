using Buisness.Abstract;
using Buisness.Constants;
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
        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
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

        public IResult Update(Color color)
        {

            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _color.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
