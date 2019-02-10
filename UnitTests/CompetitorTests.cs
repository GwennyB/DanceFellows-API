using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_DanceFellows.Data;
using API_DanceFellows.Models;
using API_DanceFellows.Models.Services;

namespace UnitTests
{
    public class CompetitorTests
    {

        //Competitors service - Creation
        /// <summary>
        /// verifies that GetCompetitor returns match when DB contains only 1 record
        /// </summary>
        [Fact]
        public async void GetCompetitor_CanGetOnlyCompetitor()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("CanGetOnlyCompetitor").Options;

            using (API_DanceFellowsDbContext _context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Competitor competitor = new Competitor();
                competitor.WSDC_ID = 1000;
                competitor.FirstName = "Joe";
                competitor.LastName = "Schmoe";

                //act
                CompetitorManagementService resultServ = new CompetitorManagementService(_context);
                await _context.Competitors.AddAsync(competitor);
                await _context.SaveChangesAsync();

                Competitor query = await resultServ.GetCompetitor(competitor.WSDC_ID);
                //assert
                Assert.Equal(competitor, query);
            }
        }

        /// <summary>
        /// verifies that GetCompetitor returns match when DB contains other records
        /// </summary>
        [Fact]
        public async void GetCompetitor_CanGetOneCompetitorFromMany()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("CanGetOneCompetitorFromMany").Options;

            using (API_DanceFellowsDbContext _context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Competitor joe = new Competitor();
                joe.WSDC_ID = 1000;
                joe.FirstName = "Joe";
                joe.LastName = "Schmoe";
                Competitor jane = new Competitor();
                jane.WSDC_ID = 2000;
                jane.FirstName = "Jane";
                jane.LastName = "Schmane";
                Competitor josh = new Competitor();
                josh.WSDC_ID = 3000;
                josh.FirstName = "Josh";
                josh.LastName = "Schmosh";

                //act
                CompetitorManagementService resultServ = new CompetitorManagementService(_context);
                await _context.Competitors.AddAsync(joe);
                await _context.Competitors.AddAsync(jane);
                await _context.Competitors.AddAsync(josh);
                await _context.SaveChangesAsync();

                Competitor query = await resultServ.GetCompetitor(jane.WSDC_ID);
                //assert
                Assert.Equal(jane, query);
            }
        }

        /// <summary>
        /// verifies that GetCompetitor returns null when no match exists in DB
        /// </summary>
        [Fact]
        public async void GetCompetitor_NoMatchReturnsNull()
        {
            //Create the options to feed into the context for dependency injection...
            DbContextOptions<API_DanceFellowsDbContext> options = new DbContextOptionsBuilder<API_DanceFellowsDbContext>().UseInMemoryDatabase("NoMatchReturnsNull").Options;

            using (API_DanceFellowsDbContext _context = new API_DanceFellowsDbContext(options))
            {
                //arrange
                Competitor joe = new Competitor();
                joe.WSDC_ID = 1000;
                joe.FirstName = "Joe";
                joe.LastName = "Schmoe";
                Competitor jane = new Competitor();
                jane.WSDC_ID = 2000;
                jane.FirstName = "Jane";
                jane.LastName = "Schmane";
                Competitor josh = new Competitor();
                josh.WSDC_ID = 3000;
                josh.FirstName = "Josh";
                josh.LastName = "Schmosh";

                //act
                CompetitorManagementService resultServ = new CompetitorManagementService(_context);
                await _context.Competitors.AddAsync(joe);
                await _context.Competitors.AddAsync(jane);
                await _context.Competitors.AddAsync(josh);
                await _context.SaveChangesAsync();

                Competitor query = await resultServ.GetCompetitor(9999);
                //assert
                Assert.Null(query);
            }
        }

    }
}
