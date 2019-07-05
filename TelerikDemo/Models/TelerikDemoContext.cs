using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelerikDemo.Models
{
    public class TelerikDemoContext : DbContext
    {
        public TelerikDemoContext(DbContextOptions<TelerikDemoContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
    }

    public class Car
    {
        public enum CarTypeEnum { SUV = 0, Saloon = 1, Hatchback = 2, Cabrio = 3,Estate = 4, Coupe = 5, MPV = 6, Liftback = 7 }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarTypeEnum CarType { get; set; }
        public bool AirConditioner { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
    }

}
