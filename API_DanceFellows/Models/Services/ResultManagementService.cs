using API_DanceFellows.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Services
{
    public class ResultManagementService
    {
        /// <summary>
        /// Standard setup for repository design pattern and dependency injection - see other services for details
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }
        public ResultManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
        }

        /// <summary>
        /// Returns the result specific to the competition and competitor ids provided.
        /// </summary>
        /// <param name="eventCompetitionId">The id for the competition whose result is to be returned from.</param>
        /// <param name="competitorId">The id for the competitor whose result is to be returned.</param>
        /// <returns>A single result corresponding to the competition and competitor provided, if it exists.</returns>
        public async Task<Result> GetResult(int eventCompetitionId, int competitorId)
        {
            return await ReadOnlyContext.Results.FirstOrDefaultAsync(res => res.EventCompetitionID == eventCompetitionId && res.CompetitorID == competitorId);
        }

        /// <summary>
        /// Takes the provided result (of a competitor in a competition at an event in a series...) and adds it to the appropriate table in the database.
        /// </summary>
        /// <param name="result">The result to be added to the database.</param>
        public async Task<Result> CreateResult(Result result)
        {
            Result added = new Result();
            if (result != null)
            {
                if (await GetResult(result.EventCompetitionID, result.CompetitorID) == null)
                {
                    ReadOnlyContext.Results.Add(result);
                    await ReadOnlyContext.SaveChangesAsync();
                    added = await ReadOnlyContext.Results.FirstOrDefaultAsync(r =>
                        r.CompetitorID == result.CompetitorID &&
                        r.EventCompetitionID == result.EventCompetitionID);
                }
            }
            return added;
        }

        /// <summary>
        /// Given a result, if the result previously existed in the table via its EventCompetition id and its Competitor ID (that is, a competitor have been registered to the event), update that result.
        /// </summary>
        /// <param name="result">The result to be updated, with updated information.</param>
        public async Task<Result> UpdateResult(Result result)
        {
            Result updated = new Result();
            if (result != null)
            {
                if (await GetResult(result.EventCompetitionID, result.CompetitorID) != null)
                {
                    var item = await ReadOnlyContext.Results.FirstOrDefaultAsync(r => r.CompetitorID == result.CompetitorID && r.EventCompetitionID == result.EventCompetitionID);
                    item.Placement = result.Placement;
                    ReadOnlyContext.Results.Update(item);
                    await ReadOnlyContext.SaveChangesAsync();
                    updated = await ReadOnlyContext.Results.FirstOrDefaultAsync(r =>
                        r.CompetitorID == result.CompetitorID &&
                        r.EventCompetitionID == result.EventCompetitionID);
                }
            }
            return updated;
        }

        /// <summary>
        /// Given the id of a competition at an event and the id of a competitor, checks if that competitor was registered in the competition, deletes the registration of the competitor, and returns the deleted registration. 
        /// </summary>
        /// <param name="eventCompetitionID">The event to deregister from.</param>
        /// <param name="competitorId">The competitor to deregister.</param>
        /// <returns>The registration that was deleted from the registration table.</returns>
        public async Task<Result> DeleteResult(int eventCompetitionID, int competitorId)
        {
            Result deleteResult = await ReadOnlyContext.Results.FirstOrDefaultAsync(res => res.EventCompetitionID == eventCompetitionID && res.CompetitorID == competitorId);
            ReadOnlyContext.Results.Remove(deleteResult);
            await ReadOnlyContext.SaveChangesAsync();
            return await ReadOnlyContext.Results.FirstOrDefaultAsync(res => res.EventCompetitionID == eventCompetitionID && res.CompetitorID == competitorId);
        }

        /// <summary>
        /// HELPER: locates a single Competition record and returns it
        /// searches by CompType, Level, and EventID since web app lacks visibility of primary key for this table
        /// </summary>
        /// <param name="compType"> CompType for record to locate </param>
        /// <param name="level"> Level for record to locate </param>
        /// <param name="eventID"> EventID for event hosting this comp </param>
        /// <returns> located EventCompetition record, or null if not found </returns>
        public async Task<EventCompetition> GetCompetition(CompType compType, Level level, int eventID)
        {
            return await ReadOnlyContext.EventCompetitions.FirstOrDefaultAsync(ec => ec.CompType == compType && ec.Level == level && ec.EventID == eventID);
        }

        /// <summary>
        /// HELPER: locates a single Competitor record and returns it
        /// </summary>
        /// <param name="id"> WSDC_ID of competitor to locate </param>
        /// <returns> Competitor object if found, or null if not </returns>
        public async Task<Competitor> GetCompetitor(int id)
        {
            return await ReadOnlyContext.Competitors.FirstOrDefaultAsync(c => c.WSDC_ID == id);
        }








        // We don't need anything below this point for MVP... although it might be useful for stretch goals, so don't delete them!



        ///// <summary>
        ///// Returns all the results currently existing from the table.
        ///// </summary>
        ///// <returns>A list of results.</returns>
        //public async Task<List<Result>> GetAllResults()
        //{
        //    return await ReadOnlyContext.Results.ToListAsync();
        //}


    }
}
