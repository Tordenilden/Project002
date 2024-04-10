using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    /// <summary>
    /// 1) Create Models
    /// 2) Install Packages (3-4)
    /// 3) Create DatabaseContext class
    /// 4) Program.cs add our Database service and connection string
    /// 4) go to console => add-migration name
    /// 5) go to console => database-update
    /// 6) Done
    /// 
    /// </summary>
    public class Samurai
    {
        //Entity Framework works with PK.... Id or ClassName+Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
    }
}
