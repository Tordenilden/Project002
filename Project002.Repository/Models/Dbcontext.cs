using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Dbcontext : DbContext
    {
        // 2 c_tor we start with one....
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {

        }
        // DbSet is "a" Table
        public DbSet<Samurai> Samurai { get; set; }
        public DbSet<Horse> Horse { get; set; }


    }
}
