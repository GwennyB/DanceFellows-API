using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_DanceFellows.Models
{
    public class Competitor
    {
        public int ID { get; set; }
        [Key]
        public int WSDC_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Level MinLevel { get; set; }
        public Level MaxLevel { get; set; }


    }

    public enum Level
    {
        Newcomer = 0,
        Novice = 1,
        Intermediate = 2,
        Advanced = 3,
        AllStar = 4,
        Champ = 5
    }
}
