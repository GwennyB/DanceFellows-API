using API_DanceFellows.Models;
using API_DanceFellows.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_DanceFellows.Controllers
{
    public class CompetitorsController : Controller
    {

        private readonly ICompetitorManager _context;

        public CompetitorsController(ICompetitorManager context)
        {
            _context = context;
        }

        [HttpGet()]
        [Route("Index")]
        public ActionResult<string> Index()
        {
            return "Hello World";
        }

        /// <summary>
        /// GET: api/Competitors/{id#}
        /// With an id specificed, hitting the Get route on Competitors should return the competitor with that id we have stored in the database. 
        /// </summary>
        /// <returns>If a competitor with the given id exists, return the competitor object with a 200 status code. If it does not, return a null object with a 400 status code.</returns>
        [HttpGet("{id}")]
        [Route("GetCompetitor")]
        // removed ("id") to make this work
        public async Task<Competitor> GetCompetitor(int id)
        {
            Competitor competitor = await _context.GetCompetitor(id);
            //Response.StatusCode tip courtesy of https://stackoverflow.com/questions/5072804/how-to-return-a-200-http-status-code-from-asp-net-mvc-3-controller
            Response.StatusCode = 200;
            if (competitor == null)
            {
                Response.StatusCode = 400;
            }
            //TODO: how should the API respond to a request with an invalid ID? Currently sending back a null object with 400 status code 
            return competitor;
        }


        /// <summary>
        /// POST: Competitors/RefreshAll
        /// calls for table dump and subsequent re-populate from external data
        /// </summary>
        /// <returns> completion report string </returns>
        [HttpGet]
        [Route("RefreshAll")]
        public async Task<string> RefreshAll()
        {
            int count = await _context.RefreshAll();
            return $"Refresh complete! Added {count} dancer records.";
        }

        ///// <summary>
        ///// GET: Competitors/RefreshExternalData
        ///// Scrapes all competitors data from external API
        ///// </summary>
        ///// <returns> dancer data </returns>
        //[HttpGet]
        //public async Task<string> RefreshExternalData(int start, int end)
        //{
        //    for (int i = 0; i < 18500; i+=250)
        //    {
        //        await _context.GetExternalData(i+1, i+250);
        //    }

        //    return "Refresh complete!";
        //}

        ///// <summary>
        ///// GET: api/Competitors (note no id appended to the end)
        ///// With no id specified, hitting the Get route on Competitors should return all competitors we have stored in the database
        ///// </summary>
        ///// <returns>A list of all competitors.</returns>
        //[HttpGet]
        //public async Task<IEnumerable<Competitor>> GetAllCompetitors()
        //{
        //    IEnumerable<Competitor> allCompetitors = await _context.GetAllCompetitors();
        //    //Response.StatusCode tip courtesy of https://stackoverflow.com/questions/5072804/how-to-return-a-200-http-status-code-from-asp-net-mvc-3-controller
        //    Response.StatusCode = 200;
        //    if (allCompetitors == null)
        //    {
        //        Response.StatusCode = 500;
        //    }
        //    return allCompetitors;
        //}

    }
}
