using Microsoft.EntityFrameworkCore;
using CSTest.Models;

namespace CSTest.Data {
    public class AppDbContent : DbContext {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }

        public DbSet<DateTemp> dateTemps { get; set; }
        public DbSet<HouseName> houseNames { get; set; }
        public DbSet<PlantName> plantNames { get; set; }
        public DbSet<HouseDetail> houseDetails { get; set; }
        public DbSet<PlantDetail> plantDetails { get; set; }
    }
}
