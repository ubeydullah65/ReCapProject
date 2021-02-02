using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=1000000,ModelYear=2001,Description="Nissan Skyline Midnight purple "},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=450000,ModelYear=1996,Description="Toyota Supra vintage black "},
                new Car{Id=3,BrandId=2,ColorId=1,DailyPrice=300000,ModelYear=2000,Description="Honda S2000 Yellow"},
                new Car{Id=4,BrandId=2,ColorId=4,DailyPrice=1500000,ModelYear=1992,Description="Honda NSX Red"},
                new Car{Id=5,BrandId=3,ColorId=3,DailyPrice=550000,ModelYear=2009,Description="BMW E92 M3 Dark Blue "}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(p=>p.Id==car.Id);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c=>c.BrandId== BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
            carUpdate.ModelYear = car.ModelYear;
        }
    }
}
