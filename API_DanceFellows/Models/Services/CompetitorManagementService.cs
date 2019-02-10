using API_DanceFellows.Data;
using API_DanceFellows.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace API_DanceFellows.Models.Services
{
    public class CompetitorManagementService : ICompetitorManager
    {

        /// <summary>
        /// Standard context for repository design patterning - create a readonly context that gets set by the constructor
        /// </summary>
        private API_DanceFellowsDbContext ReadOnlyContext { get; }
        private API_DanceFellowsDbContext _context { get; }

        /// <summary>
        /// Constructor for this service using dependency injection - sets our readonly context to the provided context when instantiating the service
        /// </summary>
        /// <param name="context">Database context to be used for this service</param>
        public CompetitorManagementService(API_DanceFellowsDbContext context)
        {
            ReadOnlyContext = context;
            _context = context;
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



    }
}
