using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFSCarbonAppMvc4.Models;

namespace NFSCarbonAppMvc4.Tests
{
    class TestData
    {
        public static IQueryable<Car> Cars
        {
            get { var cars = new List<Car>();
                for (int i = 0; i < 100; i++)
                {
                    var car = new Car();
                    car.CarReview = new List<CarReview>()
                        {
                            new CarReview() {Rating = 4}
                        };
                    cars.Add(car);
                }
                return cars.AsQueryable();
            }
        }
    }
}
