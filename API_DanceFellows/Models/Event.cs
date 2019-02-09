using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models
{
    public class Event
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }

        public ICollection<EventCompetition> EventCompetitions { get; set; }

        // foreign keys
        public int SeriesID { get; set; }

        // Navigation Properties
        //public Series Series { get; set; }
        public Series Series { get; set; }
    }
}
