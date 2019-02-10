using API_DanceFellows.Data;
using API_DanceFellows.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Services
{
    public class ResultManagementService : IResultManager
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
        /// HELPER: uses foreign object contents to build up a Result record
        /// </summary>
        /// <param name="data"> package of foreign objects to de/re-structure </param>
        /// <returns> result record </returns>
        public async Task<Result> BuildResultObject(List<object> data)
        {
            JObject comp = JObject.Parse(data[0].ToString());
            JObject participant = JObject.Parse(data[1].ToString());
            JObject compreg = JObject.Parse(data[2].ToString());
            Result result = new Result();
            result.CompetitorID = (int)participant["WSC_ID"];
            CompType a = (CompType)(int)comp["CompType"];
            Level b = (Level)(int)comp["Level"];
            int c = (int)compreg["EventID"];
            EventCompetition d = await GetCompetition(a, b, c);
            Competitor e = await GetCompetitor(result.CompetitorID);
            result.EventCompetition = d;
            result.EventCompetitionID = d.ID;
            result.Role = (Role)((int)compreg["Role"]);
            result.Competitor = e;
            result.Placement = (Placement)((int)compreg["Placement"]);
            result.ScoreChief = (int)compreg["ChiefJudgeScore"];
            result.ScoreOne = (int)compreg["JudgeOneScore"];
            result.ScoreTwo = (int)compreg["JudgeTwoScore"];
            result.ScoreThree = (int)compreg["JudgeThreeScore"];
            result.ScoreFour = (int)compreg["JudgeFourScore"];
            result.ScoreFive = (int)compreg["JudgeFiveScore"];
            result.ScoreSix = (int)compreg["JudgeSixScore"];
            return result;
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
                    item.ScoreChief = result.ScoreChief;
                    item.ScoreOne = result.ScoreOne;
                    item.ScoreTwo = result.ScoreTwo;
                    item.ScoreThree = result.ScoreThree;
                    item.ScoreFour = result.ScoreFour;
                    item.ScoreFive = result.ScoreFive;
                    item.ScoreSix = result.ScoreSix;
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
        /// HELPER: Get a single competition using comp parameters
        /// </summary>
        /// <param name="compType"> CompType (enum) </param>
        /// <param name="level"> Level (enum) </param>
        /// <param name="eventID"> EventID of associated event </param>
        /// <returns></returns>
        private async Task<EventCompetition> GetCompetition(CompType compType, Level level, int eventID)
        {
            return await ReadOnlyContext.EventCompetitions.FirstOrDefaultAsync(ec => ec.CompType == compType && ec.Level == level && ec.EventID == eventID);
        }

        /// <summary>
        /// HELPER: get a single competitor from WSDC_ID for local use
        /// </summary>
        /// <param name="id"> WSDC_ID of competitor to locate </param>
        /// <returns> competitor if found, null otherwise </returns>
        private async Task<Competitor> GetCompetitor(int id)
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