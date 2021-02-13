using System;
using Buisness.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());


            //CarTest();
            UserTest();

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserDetail();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.UserId+" "+user.FirstName+ " " + user.LastName+ " " + user.CompanyName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
           CarManager carManager = new CarManager(new EfCarDal());
            var result =carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

        }
    }
}
