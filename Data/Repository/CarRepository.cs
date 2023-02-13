using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
	public class CarRepository : IAllCars
	{

		private readonly AppDBContent appDBContent;

		public CarRepository(AppDBContent appDBContent)
		{
			this.appDBContent = appDBContent;
		}

		public IEnumerable<Car> Cars => appDBContent.Cars.Include(c => c.Category);

		public IEnumerable<Car> GetFavCars => appDBContent.Cars.Where(p => p.isFavourite).Include(c => c.Category);

		public Car getObjectCar(int carId) => appDBContent.Cars.FirstOrDefault(p => p.Id == carId);
		
	}
}
