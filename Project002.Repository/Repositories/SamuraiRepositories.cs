using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    public class SamuraiRepositories : ISamuraiRepository
    {
        private readonly Dbcontext context;
        public SamuraiRepositories(Dbcontext data)
        {
            this.context = data;
        }
        public Samurai Create(Samurai samurai)
        {
            // context is our Database!!  
            // Samurai is our Table
            context.Samurai.Add(samurai);
            context.SaveChanges();
            return samurai;
        }
    }
}
