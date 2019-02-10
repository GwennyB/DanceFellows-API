using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models
{
    public class EventCompetition
    {
        public int ID { get; set; }
        public CompType CompType { get; set; }
        public Level Level { get; set; }

        public ICollection<Result> Results { get; set; }

        // foreign keys
        public int EventID { get; set; }

        // Navigation Properties
        public Event Event { get; set; }
    }

    public enum CompType
    {
        JackAndJill = 0,
        Strictly = 1,
        Classic = 2,
        Showcase = 3,
        RisingStar = 4
    }
}
