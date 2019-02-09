using API_DanceFellows.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Services
{
    public class EventManagementService
    {
        /// <summary>
        /// Standard setup for repository design pattern and dependency injection - see CompetitorManagementService for more details
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }
        public EventManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
        }

        /// <summary>
        /// Creates a new event and adds it to the database.
        /// </summary>
        /// <param name="DFEvent">The event to be added to the database.</param>
        public async Task CreateEvent(Event DFEvent)
        {
            ReadOnlyContext.Events.Add(DFEvent);
            await ReadOnlyContext.SaveChangesAsync();
        }

        /// <summary>
        /// Returns all events from the database.
        /// </summary>
        /// <returns>A list of all events stored in the database.</returns>
        public async Task<List<Event>> GetAllEvents()
        {
            return await ReadOnlyContext.Events.ToListAsync();
        }

        /// <summary>
        /// Returns a specific event with the internal id provided as an argument.
        /// </summary>
        /// <param name="id">The id of the event to be retrieved.</param>
        /// <returns>If it exists, the event requested.</returns>
        public async Task<Event> GetEvent(int id)
        {
            //TODO: Similar to other services, see if we want to handle this better w/regard to null values
            return await ReadOnlyContext.Events.FirstOrDefaultAsync(e => e.ID == id);
        }

    }
}
