using API_DanceFellows.Models;
using API_DanceFellows.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Controllers
{
    public class EventCompetitionsController : Controller
    {
        private readonly ICompetitionManager _context;
        public EventCompetitionsController(ICompetitionManager context)
        {
            _context = context;
        }



        ///// <summary>
        ///// Creates a new competition in an event with the provided ID, using the provided competition type and level.
        ///// </summary>
        ///// <param name="eventCompetition">The new competition to be created.</param>
        ///// <returns>The ID of the competition, or null if the competition data passed in was invalid.</returns>
        //[HttpPost]
        //public async Task<int?> Create([Bind("EventID, CompType, Level")] EventCompetition eventCompetition)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Response.StatusCode = 200;
        //        await _context.CreateCompetition(eventCompetition);
        //        return eventCompetition.ID;
        //    }
        //    Response.StatusCode = 400;
        //    return null;
        //}






        // no need for GET route
        ///// <summary>
        ///// GET - gets an EventCompetition by its id, if it exists.
        ///// </summary>
        ///// <param name="ID">The id of the EventCompetition to be retrieved.</param>
        ///// <returns>An EventCompetition with the id provided, if it exists; if not, returns a null object</returns>
        //[HttpGet]
        //public async Task<EventCompetition> Get(int ID)
        //{
        //    EventCompetition eventCompetition = await _context.GetCompetition(ID);
        //    Response.StatusCode = 200;
        //    if(eventCompetition == null)
        //    {
        //        Response.StatusCode = 400;
        //    }
        //    return eventCompetition;
        //}
    }
}
