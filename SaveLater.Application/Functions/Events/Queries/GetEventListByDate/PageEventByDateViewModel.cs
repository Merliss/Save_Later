namespace SaveLater.Application.Functions.Events.Queries.GetEventListByDate
{
    public class PageEventByDateViewModel
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public int AllCount { get; set; }

        public ICollection<EventsByDateViewModel> Events { get; set; }

    }
}
