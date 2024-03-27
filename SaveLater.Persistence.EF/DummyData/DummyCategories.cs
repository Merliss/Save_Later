using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Domain.Entities;

namespace SaveLater.Persistence.EF.DummyData
{
    public class DummyCategories
    {
        public static List<Category> Get()
        {
            Category c1 = new Category()
            {
                Id = 1,
                Name = "programowanie",
                DisplayName = "Programowanie info",

            };

            Category c2 = new Category()
            {
                Id = 2,
                Name = "csharp",
                DisplayName = "C#"
            };

            Category c3 = new Category()
            {
                Id = 3,
                Name = "android",
                DisplayName = "Android info"
            };

            Category c4 = new Category()
            {
                Id = 4,
                Name = "docker",
                DisplayName = "Docker"
            };

            List<Category> c = new List<Category>() { c1, c2, c3, c4 };

            return c;
        }
    }
}
