using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models
{
    public class Result
    {
        // TODO: 'Placement' is for implementation in later module
        public Placement Placement { get; set; }
        public Role Role { get; set; }
        public int ScoreChief { get; set; }
        public int ScoreOne { get; set; }
        public int ScoreTwo { get; set; }
        public int ScoreThree { get; set; }
        public int ScoreFour { get; set; }
        public int ScoreFive { get; set; }
        public int ScoreSix { get; set; }

        // foreign keys
        public int EventCompetitionID { get; set; }
        public int CompetitorID { get; set; }

        // Navigation Properties
        public Competitor Competitor { get; set; }
        public EventCompetition EventCompetition { get; set; }
        //public object Placement { get; internal set; }
    }

    public enum Role
    {
        Lead = 0,
        Follow = 1
    }

    public enum Placement
    {
        Finalled = 0,
        [Display(Name = "Position 5")]
        Position5 = 1,
        [Display(Name = "Position 4")]
        Position4 = 2,
        [Display(Name = "Position 3")]
        Position3 = 3,
        [Display(Name = "Position 2")]
        Position2 = 4,
        [Display(Name = "Position 1")]
        Position1 = 5
    }

}
