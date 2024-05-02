using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Battle
    {
        public int BattleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime start { get; set;}
        public DateTime end { get; set;}
        public List<BattleSamurai> BattleSamurais { get; set; }=new List<BattleSamurai>();
    }
}
