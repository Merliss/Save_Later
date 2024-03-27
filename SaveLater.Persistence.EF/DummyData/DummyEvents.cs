using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Domain.Entities;

namespace SaveLater.Persistence.EF.DummyData
{
    public class DummyEvents
    {

        public static List<Event> Get()
        {
            List<Event> e = new List<Event>();

            var e1 = new Event()
            {
                Title = "Aplikacja C# od Zera Architektura, CQRS, Dobre praktyki",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(10),
                Description = @"Ustalenie architektury nie jest prostym zadaniem. Każda decyzja może mieć wielkie komplikacje potem.",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 1,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg",
                SlidesUrl = "",
                WatchFacebookLink = "",
                WatchYoutbeLink = "",
            };
            e.Add(e1);

            var e2 = new Event()
            {
                Title = "Kubernetes i Docker : Wytłumacz mi i pokaż",
                AlreadyHappend = false,
                Date = DateTime.Now.AddDays(-40),
                Description = @"Kontenery są tutaj. Kubernetes jest de facto platformą do ich uruchamiania i zarządzania.",
                FacebookEventUrl = "https://www.facebook.com/events/407358067213893/",
                Id = 2,
                ImageUrl = "https://cezarywalenciuk.pl/posts/fileswebinars/17_apliacjacsharpodzeraarchitekturacqrs.jpg",
                SlidesUrl = "https://panniebieski.github.io/webinar-Kubernetes-Docker-Wytlumacz-mi-i-pokaz/",
                WatchFacebookLink = "https://www.facebook.com/watch/live/?v=2775230679405348&ref=watch_permalink",
                WatchYoutbeLink = "https://www.youtube.com/watch?v=7g00wOg9Jto",
            };
            e.Add(e2);

            return e;
        }
    }
}
