using API_DanceFellows.Models;
using API_DanceFellows.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Controllers
{
    public class SeriesController : Controller
    {
        //DI of the service for the Series controller
        private readonly ISeriesManager _context;
        public SeriesController(ISeriesManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all series from the database.
        /// </summary>
        /// <returns>An enumerable collection of series from the database.</returns>
        [HttpGet]
        public async Task<IEnumerable<Series>> GetAll()
        {
            Response.StatusCode = 200;
            IEnumerable<Series> allSeries = await _context.GetAllSeries();
            if (allSeries == null)
            {
                Response.StatusCode = 400;
            }
            return allSeries;
        }

    }
}
