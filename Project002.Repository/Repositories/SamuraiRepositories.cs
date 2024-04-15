using Microsoft.EntityFrameworkCore;
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

        public List<Samurai> GetAll()
        {
            return context.Samurai.ToList();
        }

        public List<Horse> GetAllAndHorsie()
        {
            var result= context.Horse.Include(hest=>hest.Samurai).ToList();
            return result;
        }      
        public List<Horse> GetAllAndHorsieWHERE()
        {
            var result= context.Horse.Include(hest=>hest.Samurai).
                Where(ged=>ged.name == "gorm den tynde").ToList();
            return result;
        }
    }
}
