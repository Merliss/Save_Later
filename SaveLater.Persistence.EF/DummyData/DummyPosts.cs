using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Domain.Entities;

namespace SaveLater.Persistence.EF.DummyData
{
    public class DummyPosts
    {
        public static List<Post> Get()
        {
            var cat = DummyCategories.Get();

            Post p1 = new Post()
            {
                Author = "Damian",
                Created = DateTime.Now.AddMonths(-6),
                Description = @"Nasze aplikacje ASP.NET CORE coraz częściej są tylko aplikacją REST. To oczywiście wymaga Walidacji po stronie klienta i po stronie serwera
                Jak taką walidację jak najszybciej zrobić.Może przecież sam napisać takie warunki,
                ale przy dużej ilości klas,
                które występują jako parametry mija się to z celem.

                Możesz też skorzystać z atrybutów i oznaczyć reguły do każdej właściwości.",
                ImageUrl = "https://cezarywalenciuk.pl/Posts/programing/icons/_withbackground/R2/656_walidacja-z-fluentvalidation-waspnet-core--swagger.png",
                Id = 1,
                Rate = 8,
                CategoryId = 1,
                Title = "Walidacja z FluentValidation w ASP.NET Core + Swagger",
                Url = "https://cezarywalenciuk.pl/blog/programing/walidacja-z-fluentvalidation-waspnet-core--swagger"
            };

            Post p2 = new Post()
            {
                Author = "Ewa",
                Created = DateTime.Now.AddMonths(-4),
                Description = @"Implementacja autoryzacji i uwierzytelniania w aplikacjach ASP.NET Core jest kluczowa dla zapewnienia bezpieczeństwa.
    Często wykorzystuje się tu gotowe mechanizmy, takie jak JWT lub sesje.",
                ImageUrl = "https://example.com/your-image2.png",
                Id = 2,
                Rate = 9,
                CategoryId = 1,
                Title = "Autoryzacja i uwierzytelnianie w ASP.NET Core",
                Url = "https://example.com/your-url2"
            };

            Post p3 = new Post()
            {
                Author = "Jan",
                Created = DateTime.Now.AddMonths(-2),
                Description = @"Efektywne zarządzanie bazą danych w aplikacjach ASP.NET Core to kluczowy element wydajności i skalowalności systemu.
    Warto zastosować narzędzia ORM, takie jak Entity Framework Core, oraz pamiętać o optymalizacji zapytań.",
                ImageUrl = "https://example.com/your-image3.png",
                Id = 3,
                Rate = 7,
                CategoryId = 3,
                Title = "Zarządzanie bazą danych w ASP.NET Core + Android",
                Url = "https://example.com/your-url3"
            };

            Post p4 = new Post()
            {
                Author = "Katarzyna",
                Created = DateTime.Now.AddMonths(-1),
                Description = @"Wytwarzanie interfejsów użytkownika w aplikacjach ASP.NET Core wymaga nie tylko znajomości HTML, CSS i JavaScript,
    ale także narzędzi i bibliotek, takich jak Angular, React czy Vue.js. Docker",
                ImageUrl = "https://example.com/your-image4.png",
                Id = 4,
                Rate = 8,
                CategoryId = 4,
                Title = "Tworzenie interfejsów użytkownika w ASP.NET Core w Docker",
                Url = "https://example.com/your-url4"
            };

            List<Post> posts = new List<Post>()
            {
                p1,p2, p3, p4
            };

            return posts;
        }

    }
}
