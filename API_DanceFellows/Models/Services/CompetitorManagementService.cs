using API_DanceFellows.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Services
{
    public class CompetitorManagementService
    {

        /// <summary>
        /// Standard context for repository design patterning - create a readonly context that gets set by the constructor
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }

        /// <summary>
        /// Constructor for this service using dependency injection - sets our readonly context to the provided context when instantiating the service
        /// </summary>
        /// <param name="context">Database context to be used for this service</param>
        public CompetitorManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
        }

        /// <summary>
        /// Takes a newly created competitor and adds it to the Competitor table.
        /// </summary>
        /// <param name="competitor">Competitor to be added to the table.</param>
        /// <returns>An asynchronous task, which will always be the saving of the database table.</returns>
        public async Task CreateCompetitor(Competitor competitor)
        {
            using (var transaction = ReadOnlyContext.Database.BeginTransaction())
            {
                // kudos to MS Docs for this amazing tidbit: https://docs.microsoft.com/en-us/ef/ef6/saving/transactions
                ReadOnlyContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Competitors] ON");
                ReadOnlyContext.Competitors.Add(competitor);
                await ReadOnlyContext.SaveChangesAsync();
                ReadOnlyContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Competitors] OFF");
                transaction.Commit();
            }
        }

        /// <summary>
        /// Returns all competitors from the Competitor table.
        /// </summary>
        /// <returns> IEnumerable of all competitors from the table. </returns>
        public async Task<IEnumerable<Competitor>> GetAllCompetitors()
        {
            // Thanks to https://forums.asp.net/t/1973344.aspx?How+do+I+use+async+Task+IQueryable+ for recommending a task factory for query operations without GetAwaiter.
            return await Task.Run(() => ReadOnlyContext.Competitors.AsEnumerable<Competitor>());
        }

        /// <summary>
        /// removes a single competitor from the Competitors table
        /// </summary>
        /// <param name="id"> WSDC_ID of competitor to remove </param>
        public async Task DeleteCompetitor(int id)
        {
            var item = await ReadOnlyContext.Competitors.FirstOrDefaultAsync(c => c.WSDC_ID == id);

            if (item != null)
            {
                ReadOnlyContext.Competitors.Remove(item);
            }
        }

        /// <summary>
        /// HELPER: Saves changes just made to DB.
        /// Supports making synchronous updates to DB ( .Update() lacks GetAwaiter ) and saving after all iterations complete.
        /// </summary>
        /// <returns></returns>
        public async Task SaveThis()
        {
            await ReadOnlyContext.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a competitor from the Competitor table with the given id.
        /// </summary>
        /// <param name="id">Id to search for a competitor by.</param>
        /// <returns>A single competitor.</returns>
        public async Task<Competitor> GetCompetitor(int id)
        {
            return await ReadOnlyContext.Competitors.FirstOrDefaultAsync(comp => comp.WSDC_ID == id);
        }

        /// <summary>
        /// Given the updated state of a competitor (who already exists in the table), update the record of that competitor.
        /// </summary>
        /// <param name="comp">The competitor to be updated. If they do not already exist in the table, do not update anything.</param>
        public void UpdateCompetitor(Competitor comp)
        {
            Competitor compExists = ReadOnlyContext.Competitors.FirstOrDefault(competitor => competitor.ID == comp.ID);
            if (compExists == null)
            {
                return;
            }
            ReadOnlyContext.Competitors.Update(comp);
            ReadOnlyContext.SaveChanges();
        }

    }
}
