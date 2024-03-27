using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.EntityFrameworkCore;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Application.Functions.Events.Queries.GetEventListByDate;
using SaveLater.Domain.Entities;

namespace SaveLater.Persistence.EF.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventsRepository
    {
        public EventRepository(SaveLaterContext dbContext) : base(dbContext) 
        {
            
        }
        public async Task<List<Event>> GetPagedEventsForDate(SearchEventsOptions options, int page, int pageSize, DateTime? date)
        {
           if (options == SearchEventsOptions.MonthAndYear && date.HasValue)
            {
                return await _dbContext.Events.Where(e => e.Date.Month == date.Value.Month && e.Date.Year == date.Value.Year)
                                                    .Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
           if (options == SearchEventsOptions.Year && date.HasValue)
            {
                return await _dbContext.Events.Where(e => e.Date.Year == date.Value.Year).Skip((page - 1) *pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }
            if (options == SearchEventsOptions.Month && date.HasValue)
            {
                return await _dbContext.Events.Where(e => e.Date.Month == date.Value.Month).Skip((page - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            }

            return await _dbContext.Events.Skip((page - 1)* pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfEventsForDate(SearchEventsOptions options, DateTime? date)
        {
            if (options == SearchEventsOptions.MonthAndYear && date.HasValue)
            {
                return await _dbContext.Events.CountAsync(e => e.Date.Month == date.Value.Month && e.Date.Year == date.Value.Year);
            }
            if (options == SearchEventsOptions.Year && date.HasValue)
            {
                return await _dbContext.Events.CountAsync(e =>  e.Date.Year == date.Value.Year);
            }
            if (options == SearchEventsOptions.Month && date.HasValue)
            {
                return await _dbContext.Events.CountAsync(e => e.Date.Month == date.Value.Month);
            }
            return await _dbContext.Events.CountAsync();
        }
    }
}
