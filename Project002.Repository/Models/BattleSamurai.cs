using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class BattleSamurai
    {
        public int BattleId { get; set; }
        public Battle Battle { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }

    }
}
//            BattleId = table.Column<int>(type: "int", nullable: false),
//SamuraiId = table.Column<int>(type: "int", nullable: false)
//public int BattleSamuraiId { get; set; }