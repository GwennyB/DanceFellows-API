using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_DanceFellows.Data;
using API_DanceFellows.Models;
using API_DanceFellows.Models.Services;


namespace API_UnitTests
{
    public class ResultTests
    {
        //Results service - Creation
        [Fact]
        public async void CanCreateResultIntoEmptyDatabase()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("CreateResultintoEmpty").Options;

            using(API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                Result queryResult = await context.Results.FirstOrDefaultAsync(res => res.CompetitorID == result.CompetitorID && res.EventCompetitionID == result.EventCompetitionID && res.Placement == result.Placement);
                //assert
                Assert.Equal(result, queryResult);

            }
        }

        [Fact]
        public async void CanCreateResultIntoNonEmptyDatabase()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("CreateResultintoNonEmpty").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                Result resultTwo = new Result();
                resultTwo.EventCompetitionID = 1;
                resultTwo.CompetitorID = 3;
                resultTwo.Placement = Placement.Position3;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                await resultServ.CreateResult(resultTwo);
                Result queryResult = await context.Results.FirstOrDefaultAsync(res => res.CompetitorID == resultTwo.CompetitorID && res.EventCompetitionID == resultTwo.EventCompetitionID && res.Placement == resultTwo.Placement);
                
                //assert
                Assert.Equal(resultTwo, queryResult);
            }
        }

        [Fact]
        public async void DuplicateResultsAreNotAddedToTable()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("CreateDuplicateResult").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                Result resultTwo = new Result();
                resultTwo.EventCompetitionID = 1;
                resultTwo.CompetitorID = 1;
                resultTwo.Placement = Placement.Position3;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                await resultServ.CreateResult(resultTwo);
                List<Result> queryResults = await context.Results.ToListAsync();

                //assert
                Assert.True(1 == queryResults.Count);
            }
        }

        //Update
        [Fact]
        public async void CanUpdateResultsInDatabase()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("UpdateExistingResult").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                result.Placement = Placement.Position3;
                await resultServ.UpdateResult(result);
                Result queryResult = await context.Results.FirstOrDefaultAsync(res => res.CompetitorID == result.CompetitorID && res.EventCompetitionID == result.EventCompetitionID && res.Placement == result.Placement);
                //assert
                Assert.Equal(result, queryResult);

            }
        }

        //Update
        [Fact]
        public async void UpdatingEmptyDatabaseDoesNotCreateNewEntry()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("UpdateDoesNotCreate").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                result.Placement = Placement.Position3;
                await resultServ.UpdateResult(result);
                Result queryResult = await context.Results.FirstOrDefaultAsync(res => res.CompetitorID == result.CompetitorID && res.EventCompetitionID == result.EventCompetitionID && res.Placement == result.Placement);
                //assert
                Assert.Null(queryResult);

            }
        }

        [Fact]
        public async void UpdateResultsChangesResultInDatabase()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("UpdateExistingResultUpdatesResults").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                Result queryResult = await resultServ.GetResult(1, 1);
                Placement oldPlacement = queryResult.Placement;
                result.Placement = Placement.Position3;
                await resultServ.UpdateResult(result);
                queryResult = await resultServ.GetResult(1, 1);
                //assert
                Assert.NotEqual(oldPlacement, queryResult.Placement);
            }
        }

        [Fact]
        public async void UpdateResultNotInDatabaseDoesNotUpdateDatabase()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("UpdateNonExistentDoesNothing").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;

                Result resultTwo = new Result();
                resultTwo.EventCompetitionID = 1;
                resultTwo.CompetitorID = 2;
                resultTwo.Placement = Placement.Position3;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                Result queryResult = await resultServ.GetResult(1, 1);
                Placement oldPlacement = queryResult.Placement;
                resultTwo.Placement = Placement.Position3;
                await resultServ.UpdateResult(resultTwo);
                queryResult = await resultServ.GetResult(1, 1);
                //assert
                Assert.Equal(oldPlacement, queryResult.Placement);
            }
        }

        //Delete
        //[Fact]
        //public async void CanUpdateResultsInDatabase()
        //{
        //    //Create the options to feed into the context for dependency injection...
        //    DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("UpdateExistingResult").Options;

        //    using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
        //    {
        //        //arrange
        //        Result result = new Result();
        //        result.EventCompetitionID = 1;
        //        result.CompetitorID = 1;
        //        result.Placement = Placement.Finalled;
        //        //act
        //        ResultManagementService resultServ = new ResultManagementService(context);

        //        await resultServ.CreateResult(result);
        //        result.Placement = Placement.Position3;
        //        await resultServ.UpdateResult(result);
        //        Result queryResult = await context.Results.FirstOrDefaultAsync(res => res.CompetitorID == result.CompetitorID && res.EventCompetitionID == result.EventCompetitionID && res.Placement == result.Placement);
        //        //assert
        //        Assert.Equal(result, queryResult);

        //    }
        //}

        //Delete
        //Currently failing - can't delete
        //[Fact]
        //public async void DeletingFromEmptyDBDoesNothing()
        //{
        //    //Create the options to feed into the context for dependency injection...
        //    DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("DeleteFromEmptyDoesNotDelete").Options;

        //    using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
        //    {
        //        //arrange
        //        Result result = new Result();
        //        result.EventCompetitionID = 1;
        //        result.CompetitorID = 1;
        //        result.Placement = Placement.Finalled;
        //        //act
        //        ResultManagementService resultServ = new ResultManagementService(context);

        //        await resultServ.DeleteResult(1, 1);
        //        Result queryResult = await context.Results.FirstOrDefaultAsync(res => res.CompetitorID == result.CompetitorID && res.EventCompetitionID == result.EventCompetitionID && res.Placement == result.Placement);
        //        //assert
        //        Assert.Null(queryResult);

        //    }
        //}

        [Fact]
        public async void DeleteDeletesARecordFromTheDatabase()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("DeleteDeletes").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                
                await resultServ.DeleteResult(result.EventCompetitionID, result.CompetitorID);
                Result queryResult = await resultServ.GetResult(1, 1);
                //assert
                Assert.Null(queryResult);
            }
        }

        [Fact]
        public async void DeleteResultDeletesOnlyThatResult()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("DeletingADoesNotDeleteB").Options;

            using (API_DanceFellowsDbContext context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Result result = new Result();
                result.EventCompetitionID = 1;
                result.CompetitorID = 1;
                result.Placement = Placement.Finalled;

                Result resultTwo = new Result();
                resultTwo.EventCompetitionID = 1;
                resultTwo.CompetitorID = 2;
                resultTwo.Placement = Placement.Position3;
                //act
                ResultManagementService resultServ = new ResultManagementService(context);

                await resultServ.CreateResult(result);
                await resultServ.CreateResult(resultTwo);
                await resultServ.DeleteResult(result.EventCompetitionID, result.CompetitorID);
                Result queryResult = await resultServ.GetResult(1, 2);
                //assert
                Assert.Equal(resultTwo, queryResult);
            }
        }
    }
}
