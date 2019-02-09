using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models
{
    public class Series
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Event> SeriesEvents { get; set; }

        // Navigation Properties

    }
}
