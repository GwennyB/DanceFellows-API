using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Interfaces
{
    /// <summary>
    /// Interface for managing swing dance competitors. Let us create a new competitor (should only be used when seeding at the moment), get a competitor by internal ID, get all competitors, and update a competitor with new information from the API.
    /// </summary>
    public interface ICompetitorManager
    {
        //Get a competitor by internal ID
        Task<Competitor> GetCompetitor(int id);

    }
}

