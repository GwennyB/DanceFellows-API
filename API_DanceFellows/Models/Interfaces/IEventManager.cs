using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Interfaces
{
    /// <summary>
    /// Interface for managing an instance of an event from a series. Lets us create a new event, get an event by its internal ID, and get all events.
    /// </summary>
    public interface IEventManager
    {
        //Create a new Event
        Task CreateEvent(Event DFEvent);

        //Get a Event by its internal ID
        Task<Event> GetEvent(int id);

        //Get all events
        Task<List<Event>> GetAllEvents();
    }
}

