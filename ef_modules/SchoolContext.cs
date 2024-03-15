using ef_models;
using Microsoft.EntityFrameworkCore;

namespace ef_models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<Delivery> Delivery { get; set; }

        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Xuesheng> Xuesheng { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        //}
    }
}


