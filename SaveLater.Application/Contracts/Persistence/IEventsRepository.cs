using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Contracts.Persistence
{
    internal interface IEventsRepository : IAsyncRepository<Event>
    {
    }
}
