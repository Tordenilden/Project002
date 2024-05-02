using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Models
{
    public class Dbcontext : DbContext
    {
        string horseColor = "blabla";
        //Horse myhorse = new Horse("");
        
        // 2 c_tor we start with one....
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {

        }
        // DbSet is "a" Table
        public DbSet<Samurai> Samurai { get; set; }
        public DbSet<Horse> Horse { get; set; }
        public DbSet<Battle> Battle { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create Objects ... Horse, etc.
            int tal; // Erklarung
            string s1 = "Hansi nissemand"; // Initialisering
            string s2 = new string("Elefantmanden");
            Horse myhorse = new Horse() {
                HorseId = 5, 
                name = "Bo",
                SamuraiId = 1,
                Samurai = new Samurai() { }
            };
            Horse omg = new Horse(){HorseId = 5,name = "Bo",SamuraiId = 1,Samurai = new Samurai()};
            modelBuilder.Entity<Horse>().HasData(myhorse);
            modelBuilder.Entity<Horse>().HasData(omg);


            //EF version 5.0 works!!
            //EF version 6.0 I have to try or Dennis helps me




            //            public int BattleSamuraiId { get; set; }
            //public int BattleId { get; set; }
            //public int SamuraiId { get; set; }
            /*****************************************************************************************/
            // Configure
            //modelBuilder.Entity<Samurai>()
            //    .HasMany(left => left.Battle)
            //    .WithMany(right => right.Samurai)
            //    .UsingEntity<BattleSamurai>(
            //        right => right.HasOne(e => e.SamuraiId).WithMany(),
            //        left => left.HasOne(e => e.s).WithMany().HasForeignKey(e => e.SamuraiId)
            //    );


           // Configure many-to - many relationship
            modelBuilder.Entity<BattleSamurai>()
                .HasKey(pc => new { pc.SamuraiId, pc.BattleId });

            modelBuilder.Entity<BattleSamurai>()
                .HasOne(pc => pc.Samurai)
                .WithMany(p => p.BattleSamurais)
                .HasForeignKey(pc => pc.SamuraiId);

            modelBuilder.Entity<BattleSamurai>()
                .HasOne(pc => pc.Battle)
                .WithMany(c => c.BattleSamurais)
                .HasForeignKey(pc => pc.BattleId);


            /*****************************************************************************************/
            /*****************************************************************************************/
            /*****************************************************************************************/


            Samurai sam1 = new Samurai { Id = 10, Age = 20, Name = "Ulla Skallesmækker", Description = "This is serios" };
            Samurai sam2 = new Samurai { Id = 20, Age = 20, Name = "Ulla BrainFLuid", Description = "This is serios" };

            Battle battle1 = new Battle { BattleId = 100, Name = "Imperious", Description = "Really bad", start = new DateTime(2024, 04, 16), end = new DateTime(2024, 04, 18) };
            Battle battle2 = new Battle { BattleId = 200, Name = "FUnny", Description = "Really bad",
                start = new DateTime(2024, 03, 16),
                end = new DateTime(2024, 04, 18)
            };

           // sam1.Battle = new List<Battle> { battle1, battle2 };
            //battle1.Samurai = new List<Samurai> { sam1 };


          modelBuilder.Entity<Samurai>().HasData(sam1);
          modelBuilder.Entity<Battle>().HasData(battle1);
          modelBuilder.Entity<Samurai>().HasData(sam2);
          modelBuilder.Entity<Battle>().HasData(battle2);

          modelBuilder.Entity<BattleSamurai>().HasData(
               new BattleSamurai { BattleId = 100, SamuraiId = 10 },
               new BattleSamurai { BattleId = 200, SamuraiId = 10 }
               );
            //modelBuilder.Entity<BattleSamurai>().HasData(
            //   new BattleSamurai { BattleSamuraiId = 1, BattleId = 100, SamuraiId = 10 }
            //   );


            //  modelBuilder.Entity<Battle>().HasData(battle1, battle2);

            //modelBuilder.Entity<Samurai>().HasData(
            //    new Models.Samurai { Id = 1, Age = 20, Name = "Ulla Skallesmækker", Description = "This is serios" },
            //    new Models.Samurai { Id = 2, Age = 20, Name = "Ulla BrainFLuid", Description = "This is serios" });

            //modelBuilder.Entity<Samurai>().HasData(
            //    sam1, sam2
            //    );

            ///**************************************************************************************/


            //modelBuilder.Entity<Battle>().HasData(
            //    new Battle { BattleId = 100, Name = "Imperious", Description = "Really bad", start = new DateTime(2024, 04, 16), end = new DateTime(2024, 04, 18) },
            //    new Battle { BattleId = 200, Name = "FUnny", Description = "Really bad", start = new DateTime(2024, 03, 16), end = new DateTime(2024, 04, 18) }
            //    );


            //Book book = new Book { BookId = 1, Title = "Brave New World" };
            //Category category = new Category { CategoryId = 1, CategoryName = "Dystopian" };

            //// Assign the relationship
            //category.Books = new List<Book> { book };
            //book.Categories = new List<Category> { category };

            // Seed the data
            //modelBuilder.Entity<Book>().HasData(book);
            //modelBuilder.Entity<Category>().HasData(category);
            //modelBuilder.Entity<Battle>().HasData(
            //    new Battle { Id = 10, Name = "Imperious", Description = "Really bad", start = new DateTime(2024, 04, 16), end = new DateTime(2024, 04, 18), Samurai = new List<Samurai> { sam1 } },
            //    new Battle { Id = 20, Name = "FUnny", Description = "Really bad", start = new DateTime(2024, 03, 16), end = new DateTime(2024, 04, 18), Samurai = new List<Samurai> { sam2 } }
            //    );
            //name: "BattleSamurai",
            //        columns: table => new
            //        {
            //            BattleId = table.Column<int>(type: "int", nullable: false),
            //            SamuraiId = table.Column<int>(type: "int", nullable: false)
            //        }

            //modelBuilder.Entity<Samurai>()
            //.HasMany(g => g.Battle)
            //.WithMany(s => s.Samurai)
            //.UsingEntity<Dictionary<string, object>>(
            //"BattleSamurai",
            //j => j.HasOne<Battle>().WithMany().HasForeignKey("Id"),
            //j => j.HasOne<Samurai>().WithMany().HasForeignKey("Id"));

            //  modelBuilder.Entity<Samurai>()
            //  .HasMany(g => g.Battle)
            //  .WithMany(s => s.Samurai).
            //  UsingEntity<Dictionary<string, object>>(
            //  "BattleSamurai",
            //  j => j.HasOne<Battle>().WithMany().HasForeignKey("BattleId"),
            //  j => j.HasOne<Samurai>().WithMany().HasForeignKey("SamuraiId"));





            //// modelBuilder.Entity<BattleSamurai>().HasData(1, 10, 10);
            //  modelBuilder.Entity<BattleSamurai>().HasData(
            //      new BattleSamurai { BattleSamuraiId=1, BattleId= 10, SamuraiId =10}
            //      );


            //"BattleSamurai",
            //j => j.HasOne<Battle>().WithMany().HasForeignKey("Id"),
            //j => j.HasOne<Samurai>().WithMany().HasForeignKey("Id"))




            //modelBuilder.Entity<BattleSamurai>().HasData(
            //    new BattleSamurai { BattleSamuraiId=1,BattleId = 10, SamuraiId = 10 }
            //    );


        }


    }
}

//modelBuilder.Entity<Samurai>()
//.HasMany(g => g.Battle)
//.WithMany(s => s.Samurai).
//UsingEntity<Dictionary<string, object>>(
//"BattleSamurai",
//j => j.HasOne<Battle>().WithMany().HasForeignKey("BattleId"),
//j => j.HasOne<Samurai>().WithMany().HasForeignKey("SamuraiId"));