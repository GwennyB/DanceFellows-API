using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Interfaces
{
    /// <summary>
    /// Interface for managing competitions. Currently covers the creation of a new competition, finding a specific competition by the event it took place at, the type of competition, and its level, and grabbing all competitions.
    /// </summary>
    public interface ICompetitionManager
    {
        //Create a new competition
        //Task CreateCompetition(EventCompetition competition);




        //TODO: don't need anything below this point

        //Get a competition by its composite key
        //Task<EventCompetition> GetCompetition(int id);

        //Get all competitions (presumably for filtering)
        //Task<List<EventCompetition>> GetAllCompetitions();
    }
}

