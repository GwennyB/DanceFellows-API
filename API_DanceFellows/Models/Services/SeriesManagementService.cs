using API_DanceFellows.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Services
{
    public class SeriesManagementService
    {
        /// <summary>
        /// Standard setup for DI and repository design patterns - see CompetitorManagementService for more detail
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }
        public SeriesManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
        }

        /// <summary>
        /// Adds the provided series (of swing dance events) to the appropriate table.
        /// </summary>
        /// <param name="series">The series to be added to the database.</param>
        public async Task CreateSeries(Series series)
        {
            ReadOnlyContext.Series.Add(series);
            await ReadOnlyContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all of the series present in the database and returns them as a list.
        /// </summary>
        /// <returns>A list containing all of the series from the database.</returns>
        public async Task<IEnumerable<Series>> GetAllSeries()
        {
            return await ReadOnlyContext.Series.ToListAsync();
        }

        /// <summary>
        /// Given an id, returns the series corresponding to the id, if the id exists.
        /// </summary>
        /// <param name="id">The id of the series to be found.</param>
        /// <returns>If it exists, a series with the id provided.</returns>
        public async Task<Series> GetSeries(int id)
        {
            return await ReadOnlyContext.Series.FirstOrDefaultAsync(series => series.ID == id);
        }

    }
}
