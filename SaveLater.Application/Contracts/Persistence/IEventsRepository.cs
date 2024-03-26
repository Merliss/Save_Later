using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Application.Functions.Events.Queries.GetEventListByDate;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Contracts.Persistence
{
    public interface IEventsRepository : IAsyncRepository<Event>
    {

        Task<int> GetTotalCountOfEventsForDate(SearchEventsOptions options, DateTime? date);
        Task<List<Event>> GetPagedEventsForDate(SearchEventsOptions options, int page, int pageSize, DateTime? date);
    }
}
