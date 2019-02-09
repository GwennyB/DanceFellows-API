using API_DanceFellows.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DanceFellows.Data
{
    public class API_DanceFellowsDbContext : DbContext
    {
        public API_DanceFellowsDbContext(DbContextOptions<API_DanceFellowsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Build composite key for Result
            modelBuilder.Entity<Result>().HasKey(item => new { item.EventCompetitionID, item.CompetitorID });
            // Build composite key for EventCompetition
            // deprecated - added a Primary ID to EventCompetition table
            //modelBuilder.Entity<EventCompetition>().HasKey(ce => new { ce.CompType, ce.Level, ce.EventID });
            modelBuilder.Entity<Competitor>().HasKey(item => item.WSDC_ID);


            modelBuilder.Entity<Competitor>().HasData(
                    new Competitor
                    {
                        ID = 1,
                        WSDC_ID = 8717,
                        FirstName = "David",
                        LastName = "Buchthal",
                        MinLevel = Level.Intermediate,
                        MaxLevel = Level.Advanced
                    },
                    new Competitor
                    {
                        ID = 2,
                        WSDC_ID = 14007,
                        FirstName = "Gwen",
                        LastName = "Zubatch",
                        MinLevel = Level.Novice,
                        MaxLevel = Level.Novice
                    }
                );

            modelBuilder.Entity<Series>().HasData(
                    new Series
                    {
                        ID = 1,
                        Name = "Seattle Easter Swing",
                        Location = "Bellevue, WA"
                    },
                    new Series
                    {
                        ID = 2,
                        Name = "Swingcouver",
                        Location = "Vancouver, BC"
                    },
                    new Series
                    {
                        ID = 3,
                        Name = "Sea To Sky",
                        Location = "Seattle, WA"
                    },
                    new Series
                    {
                        ID = 4,
                        Name = "Rose City Swing",
                        Location = "Portland, OR"
                    },
                    new Series
                    {
                        ID = 5,
                        Name = "US Open Swing Dance Championships",
                        Location = "Burbank, CA"
                    }
                );

            modelBuilder.Entity<Event>().HasData(
                    new Event
                    {
                        ID = 1,
                        Year = 2019,
                        Director = "Allen Ulbricht",
                        SeriesID = 1
                    },
                    new Event
                    {
                        ID = 2,
                        Year = 2019,
                        Director = "John Kirkconnell",
                        SeriesID = 2
                    },
                    new Event
                    {
                        ID = 3,
                        Year = 2019,
                        Director = "Mike Kielbasa",
                        SeriesID = 3
                    },
                    new Event
                    {
                        ID = 4,
                        Year = 2019,
                        Director = "Babek Shakeri",
                        SeriesID = 4
                    },
                    new Event
                    {
                        ID = 5,
                        Year = 2019,
                        Director = "Phil Dorroll",
                        SeriesID = 5
                    }
                );
            modelBuilder.Entity<EventCompetition>().HasData(
                    new EventCompetition
                    {
                        ID = 1,
                        CompType = CompType.JackAndJill,
                        Level = Level.Novice,
                        EventID = 1,
                    },
                    new EventCompetition
                    {
                        ID = 2,
                        CompType = CompType.JackAndJill,
                        Level = Level.Intermediate,
                        EventID = 1,
                    },
                    new EventCompetition
                    {
                        ID = 3,
                        CompType = CompType.JackAndJill,
                        Level = Level.Advanced,
                        EventID = 1,
                    },
                    new EventCompetition
                    {
                        ID = 4,
                        CompType = CompType.JackAndJill,
                        Level = Level.AllStar,
                        EventID = 1,
                    },
                    new EventCompetition
                    {
                        ID = 5,
                        CompType = CompType.JackAndJill,
                        Level = Level.Champ,
                        EventID = 1,
                    }
                );
            modelBuilder.Entity<Result>().HasData(
                new Result
                {
                    CompetitorID = 8717,
                    EventCompetitionID = 3,
                },
                new Result
                {
                    CompetitorID = 14007,
                    EventCompetitionID = 1,
                }
            );
        }

        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCompetition> EventCompetitions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Series> Series { get; set; }
    }
}
