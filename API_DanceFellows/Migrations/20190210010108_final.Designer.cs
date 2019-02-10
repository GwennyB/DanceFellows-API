﻿// <auto-generated />
using API_DanceFellows.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_DanceFellows.Migrations
{
    [DbContext(typeof(API_DanceFellowsDbContext))]
    [Migration("20190210010108_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_DanceFellows.Models.Competitor", b =>
                {
                    b.Property<int>("WSDC_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<int>("ID");

                    b.Property<string>("LastName");

                    b.Property<int>("MaxLevel");

                    b.Property<int>("MinLevel");

                    b.HasKey("WSDC_ID");

                    b.ToTable("Competitors");

                    b.HasData(
                        new
                        {
                            WSDC_ID = 8717,
                            FirstName = "David",
                            ID = 1,
                            LastName = "Buchthal",
                            MaxLevel = 3,
                            MinLevel = 2
                        },
                        new
                        {
                            WSDC_ID = 14007,
                            FirstName = "Gwen",
                            ID = 2,
                            LastName = "Zubatch",
                            MaxLevel = 1,
                            MinLevel = 1
                        });
                });

            modelBuilder.Entity("API_DanceFellows.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director");

                    b.Property<int>("SeriesID");

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("SeriesID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Director = "Allen Ulbricht",
                            SeriesID = 1,
                            Year = 2019
                        },
                        new
                        {
                            ID = 2,
                            Director = "John Kirkconnell",
                            SeriesID = 2,
                            Year = 2019
                        },
                        new
                        {
                            ID = 3,
                            Director = "Mike Kielbasa",
                            SeriesID = 3,
                            Year = 2019
                        },
                        new
                        {
                            ID = 4,
                            Director = "Babek Shakeri",
                            SeriesID = 4,
                            Year = 2019
                        },
                        new
                        {
                            ID = 5,
                            Director = "Phil Dorroll",
                            SeriesID = 5,
                            Year = 2019
                        });
                });

            modelBuilder.Entity("API_DanceFellows.Models.EventCompetition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompType");

                    b.Property<int>("EventID");

                    b.Property<int>("Level");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.ToTable("EventCompetitions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CompType = 0,
                            EventID = 1,
                            Level = 1
                        },
                        new
                        {
                            ID = 2,
                            CompType = 0,
                            EventID = 1,
                            Level = 2
                        },
                        new
                        {
                            ID = 3,
                            CompType = 0,
                            EventID = 1,
                            Level = 3
                        },
                        new
                        {
                            ID = 4,
                            CompType = 0,
                            EventID = 1,
                            Level = 4
                        },
                        new
                        {
                            ID = 5,
                            CompType = 0,
                            EventID = 1,
                            Level = 5
                        });
                });

            modelBuilder.Entity("API_DanceFellows.Models.Result", b =>
                {
                    b.Property<int>("EventCompetitionID");

                    b.Property<int>("CompetitorID");

                    b.Property<int>("Placement");

                    b.Property<int>("Role");

                    b.Property<int>("ScoreChief");

                    b.Property<int>("ScoreFive");

                    b.Property<int>("ScoreFour");

                    b.Property<int>("ScoreOne");

                    b.Property<int>("ScoreSix");

                    b.Property<int>("ScoreThree");

                    b.Property<int>("ScoreTwo");

                    b.HasKey("EventCompetitionID", "CompetitorID");

                    b.HasIndex("CompetitorID");

                    b.ToTable("Results");

                    b.HasData(
                        new
                        {
                            EventCompetitionID = 3,
                            CompetitorID = 8717,
                            Placement = 0,
                            Role = 0,
                            ScoreChief = 0,
                            ScoreFive = 0,
                            ScoreFour = 0,
                            ScoreOne = 0,
                            ScoreSix = 0,
                            ScoreThree = 0,
                            ScoreTwo = 0
                        },
                        new
                        {
                            EventCompetitionID = 1,
                            CompetitorID = 14007,
                            Placement = 0,
                            Role = 0,
                            ScoreChief = 0,
                            ScoreFive = 0,
                            ScoreFour = 0,
                            ScoreOne = 0,
                            ScoreSix = 0,
                            ScoreThree = 0,
                            ScoreTwo = 0
                        });
                });

            modelBuilder.Entity("API_DanceFellows.Models.Series", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Series");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Location = "Bellevue, WA",
                            Name = "Seattle Easter Swing"
                        },
                        new
                        {
                            ID = 2,
                            Location = "Vancouver, BC",
                            Name = "Swingcouver"
                        },
                        new
                        {
                            ID = 3,
                            Location = "Seattle, WA",
                            Name = "Sea To Sky"
                        },
                        new
                        {
                            ID = 4,
                            Location = "Portland, OR",
                            Name = "Rose City Swing"
                        },
                        new
                        {
                            ID = 5,
                            Location = "Burbank, CA",
                            Name = "US Open Swing Dance Championships"
                        });
                });

            modelBuilder.Entity("API_DanceFellows.Models.Event", b =>
                {
                    b.HasOne("API_DanceFellows.Models.Series", "Series")
                        .WithMany("SeriesEvents")
                        .HasForeignKey("SeriesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_DanceFellows.Models.EventCompetition", b =>
                {
                    b.HasOne("API_DanceFellows.Models.Event", "Event")
                        .WithMany("EventCompetitions")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_DanceFellows.Models.Result", b =>
                {
                    b.HasOne("API_DanceFellows.Models.Competitor", "Competitor")
                        .WithMany()
                        .HasForeignKey("CompetitorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API_DanceFellows.Models.EventCompetition", "EventCompetition")
                        .WithMany("Results")
                        .HasForeignKey("EventCompetitionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
