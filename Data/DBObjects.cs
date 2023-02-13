using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
	public class DBObjects
	{
		public static void Initial(AppDBContent content)
		{
            
			
			if (!content.Categories.Any())
			{
				content.Categories.AddRange(Categories.Select(c => c.Value));
			}

			if (!content.Cars.Any())
			{
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        shortDesc = "Тихий и спокойный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/ford_fiesta.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        shortDesc = "Дерзкий и стильный",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/bmw_m3.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Mersedes C class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Удобный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = Categories["Классические автомобили"]
                    }
                    );
			}
            content.SaveChanges();
		}

		private static Dictionary<string, Category> category;

		public static Dictionary<string, Category> Categories
		{
			get 
			{ 
				if(category == null)
				{
					var list = new Category[]
					{
                        new Category { categoryName = "Электромобили", desc = "Современный вид транспорта" },
						new Category { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
						category.Add(el.categoryName, el);
                    }
                }

				return category;
			}
		}
	}
}
