using API_DanceFellows.Models;
using API_DanceFellows.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Controllers
{
    public class ResultsController : Controller
    {
        private readonly IResultManager _context;

        public ResultsController(IResultManager context)
        {
            _context = context;
        }



        /// <summary>
        /// Creates a new result with a given placement, competition ID, and Competitor ID.
        /// </summary>
        /// <param name="result">The result to be created.</param>
        /// <returns>A response with status code 200 if the ModelState was valid, or 400 if it was not.</returns>
        [HttpPost]
        [Route("Create")]
        public async Task<Result> Create([FromBody] List<object> data)
        {
            Result result = await _context.BuildResultObject(data);
            Result added = await _context.CreateResult(result);

            Response.StatusCode = 200;

            //Need to ensure that there were no issues with binding, as per https://stackoverflow.com/questions/19490121/need-guide-line-for-mvc-action-method-with-bind-attribute
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return null;
            }
            return added;
        }

        /// <summary>
        /// If a result exists with the given competition ID and competitor ID exists, update the result with the provided information.
        /// </summary>
        /// <param name="data"> List of objects: Participant, RegisteredCompetitor, Competition </param>
        /// <returns>A response with status code 200 if the ModelState was valid, or 400 if it was not.</returns>
        [HttpPut]
        [Route("Update")]
        public async Task<Result> Update([FromBody]List<object> data)
        {
            Result result = await _context.BuildResultObject(data);
            Result updated = await _context.UpdateResult(result);

            Response.StatusCode = 200;
            if (!ModelState.IsValid || _context.GetResult(result.EventCompetitionID, result.CompetitorID) == null)
            {
                Response.StatusCode = 400;
                return null;
            }
            Response.StatusCode = 200;
            await _context.UpdateResult(result);
            return updated;
        }


        /// <summary>
        /// If a result exists with the given competition ID and competitor ID exists, delete it.
        /// </summary>
        /// <param name="result">The result to be deleted.</param>
        /// <returns>The result that was deleted, or a null object if it did not exist.</returns>
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] List<object> data)
        {
            Result result = await _context.BuildResultObject(data);
            Result deleted = await _context.DeleteResult(result.EventCompetitionID, result.CompetitorID);

            Response.StatusCode = 200;

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return NotFound();
            }
            return Ok();
        }






        // TODO: Don't need Placement on creation - we create the Result object when the competitor gets registered for the competition (Placement stays blank until competition is scored).
        // TODO: Need to receive EventID, CompType, and Level instead of EventCompetitionID - front side doesn't have access to EventCompetitionID
        //Model binding courtesy of https://stackoverflow.com/questions/19490121/need-guide-line-for-mvc-action-method-with-bind-attribute


        ///// <summary>
        ///// GET: Results (note no id appended to the end)
        ///// With no id specified, hitting the Get route for Results returns the entire table of results back as a IEnumerable collection. 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IEnumerable<Result>> Get()
        //{
        //    IEnumerable<Result> allResults = await _context.GetAllResults();
        //    Response.StatusCode = 200;
        //    if (allResults == null)
        //    {
        //        Response.StatusCode = 400;
        //    }
        //    return allResults;
        //}



        ////Get with multiple parameters syntax found at https://stackoverflow.com/questions/36280947/how-to-pass-multiple-parameters-to-a-get-method-in-asp-net-core/36287271
        ///// <summary>
        ///// GET: Results/eventCompetitionID/competitorID
        ///// With both ids specified, hitting the Get route returns a single result from a competition for a given competitor.
        ///// </summary>
        ///// <param name="eventCompetitionId">ID of the competition to get the result from.</param>
        ///// <param name="competitorId">ID of the competitor whose results are to be retrieved.</param>
        ///// <returns>A single result for the given competitor from the given competition.</returns>
        //[HttpGet("{eventCompetitionId}/{competitorId}")]
        //public async Task<Result> Get(int eventCompetitionId, int competitorId)
        //{
        //    Result result = await _context.GetResult(eventCompetitionId, competitorId);
        //    Response.StatusCode = 200;
        //    if (result == null)
        //    {
        //        Response.StatusCode = 400;
        //    }
        //    return result;
        //}

    }
}
