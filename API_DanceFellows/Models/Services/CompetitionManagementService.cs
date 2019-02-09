using API_DanceFellows.Data;
using API_DanceFellows.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Services
{
    public class CompetitionManagementService : ICompetitionManager
    {

        /// <summary>
        /// Standard setup for repository design pattern and dependency injection - see CompetitorManagementService for a bit more detail
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }
        public CompetitionManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
        }

        /// <summary>
        /// Creates an instance of a competition assocated with an event in a series to the appropriate table in the database.
        /// </summary>
        /// <param name="competition">Competition to be added into the database</param>
        /// <returns>An asynchronous task that clears once complete.</returns>
        public async Task CreateCompetition(EventCompetition competition)
        {
            if (competition != null)
            {
                if (await GetCompetition(competition.ID) == null)
                {
                    ReadOnlyContext.EventCompetitions.Add(competition);
                    await ReadOnlyContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Gets a specific competition, given an event, the type of competition, and the level of the competition.
        /// </summary>
        /// <param name="eventId">The id of the event that the competition took place at.</param>
        /// <param name="compType">The type of competition being retrieved.</param>
        /// <param name="level">The level of competition being retrieved.</param>
        /// <returns>If it exists, the first competition matching the parameteres entered.</returns>
        private async Task<EventCompetition> GetCompetition(int id)
        {
            return await ReadOnlyContext.EventCompetitions.FirstOrDefaultAsync(comp => comp.ID == id);
        }




        // TODO: don't need anything below this point

        ///// <summary>
        ///// Gets a list of all competitions from all recorded events.
        ///// </summary>
        ///// <returns>A list of competitions.</returns>
        //public async Task<List<EventCompetition>> GetAllCompetitions()
        //{
        //    return await ReadOnlyContext.EventCompetitions.ToListAsync();
        //}
    }
}
