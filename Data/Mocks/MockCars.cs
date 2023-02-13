using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> Cars {
            get 
            {
                return new List<Car>
                {
                    new Car {
                        Name = "Tesla", 
                        shortDesc = "Быстрый автомобиль", 
                        longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg", 
                        price = 45000, 
                        isFavourite = true, 
                        available = false, 
                        Category = _carsCategory.AllCategories.First()
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        shortDesc = "Тихий и спокойный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/ford_fiesta.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = _carsCategory.AllCategories.First()
                    },
                    new Car {
                        Name = "BMW M3",
                        shortDesc = "Дерзкий и стильный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/bmw_m3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = _carsCategory.AllCategories.Last()
                    },
                    new Car {
                        Name = "Mersedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = _carsCategory.AllCategories.Last()
                    },
                };
            }
                
        }
        public IEnumerable<Car> GetFavCars { get; set ; }

        public Car getObjectCar(int carId) { throw new System.Exception(); }
    }
}
