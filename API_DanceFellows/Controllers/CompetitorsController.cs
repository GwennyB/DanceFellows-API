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

        /// <summary>
        /// default greeting route
        /// </summary>
        /// <returns> Hello World </returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("")]
        [Route("Index")]
        [Route("index.html")]
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
        public async Task<Competitor> GetCompetitor(int id)
        {
            Competitor competitor = await _context.GetCompetitor(id);
            //Response.StatusCode tip courtesy of https://stackoverflow.com/questions/5072804/how-to-return-a-200-http-status-code-from-asp-net-mvc-3-controller
            Response.StatusCode = 200;
            if (competitor == null)
            {
                Response.StatusCode = 400;
            }
            return competitor;
        }

    }
}
