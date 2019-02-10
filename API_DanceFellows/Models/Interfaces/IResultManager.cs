using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Interfaces
{
    /// <summary>
    /// Interface for managing a specific result from a competition at an event in a series. Currently lets us create a new association, get a specific result, or get all results.
    /// </summary>
    public interface IResultManager
    {
        //Create a new result
        Task<Result> CreateResult(Result result);

        //Get a result via composite key of competition instance in an event and a competitor's ID
        Task<Result> GetResult(int eventCompetitionId, int competitorId);

        //Update a specific result (used in adding or changing scoring)
        Task<Result> UpdateResult(Result result);

        //Delete a result (used in unregistering a competitor)
        Task<Result> DeleteResult(int eventCompetitionID, int competitorId);
        
        // use foreign object contents to build up Result record
        Task<Result> BuildResultObject(List<object> data);




        //// Get competitionID given Comptype, Level, and EventID
        //Task<EventCompetition> GetCompetition(CompType compType, Level level, int eventID);
        
        //Task<Competitor> GetCompetitor(int id);


        ////Get all results
        //Task<List<Result>> GetAllResults();

    }
}

