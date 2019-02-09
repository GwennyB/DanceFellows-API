

using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_DanceFellows.Models.Interfaces
{
    /// <summary>
    /// Interface for mananging a series of events. Lets us create a new series, get a specific series by internal ID, and get all series.
    /// </summary>
    public interface ISeriesManager
    {
        //Create a new series
        Task CreateSeries(Series series);

        //Get a series by its internal ID
        Task<Series> GetSeries(int id);

        //Get all series (presumably for filtering)
        Task<IEnumerable<Series>> GetAllSeries();
    }
}

