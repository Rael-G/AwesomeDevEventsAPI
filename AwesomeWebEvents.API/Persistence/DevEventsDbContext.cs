using AwesomeWebEvents.API.Entities;

namespace AwesomeWebEvents.API.Persistence
{
    public class DevEventsDbContext
    {
        public List<DevEvent> DevEvents { get; set; }

        public DevEventsDbContext()
        {
            DevEvents = new List<DevEvent>();
        }
    }
}
