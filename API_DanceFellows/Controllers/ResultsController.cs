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
        [Route("Results/Create")]
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
        [Route("Results/Update")]
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
        [Route("Results/Delete")]
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


    }
}
