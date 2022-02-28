using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<CourseAndDateRelation> CoursesAndDateRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
            }
    }
}
