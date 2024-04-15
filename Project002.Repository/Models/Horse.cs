using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Horse
    {
        public int HorseId { get; set; } // PK
        public string name { get; set; }
        public int SamuraiId { get; set; } // FK to Samurai table
        public Samurai Samurai { get; set; } = new Samurai();

        // If I had a List or Model I would not have in "Swagger"
        // [JSONIgnore] and ? in the Property
        //[JsonIgnore]
        //public List<Samurai> ?SamuraiList { get; set; }

    }
}
