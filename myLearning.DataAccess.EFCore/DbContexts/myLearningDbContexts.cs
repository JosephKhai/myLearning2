using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myLearning.Common.DataAccess.EFCore;
using myLearning.DataAccess.EFCore.Configuration;
using myLearning.Entities;

namespace myLearning.DataAccess.EFCore.DbContexts
{
    public class myLearningDbContexts : CommonDbContext
    {
        public myLearningDbContexts(DbContextOptions options, IConfiguration configuration) : base(options, configuration)
        {
        }

        public DbSet<City> Cities => Set<City>();
        public DbSet<Country> Countries => Set<Country>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EntityTypeConfiguration classes
            //modelBuilder.ApplyConfiguration(new CityConfig());
            //modelBuilder.ApplyConfiguration(new CountryConfig());


            ////OR Fluet API
            //modelBuilder.Entity<City>().ToTable("Cities");
            //modelBuilder.Entity<City>()
            //    .HasKey(x => x.Id);
            //modelBuilder.Entity<City>()
            //    .Property(x => x.Id).IsRequired();
            //modelBuilder.Entity<City>()
            //    .Property(x => x.Lat).HasColumnType("decimal(7,4)");
            //modelBuilder.Entity<City>()
            //    .Property(x => x.Lon).HasColumnType("decimal(7,4)");


            //modelBuilder.Entity<Country>().ToTable("Countries");
            //modelBuilder.Entity<Country>()
            //    .HasKey(x => x.Id);
            //modelBuilder.Entity<Country>()
            //    .Property(x => x.Id).IsRequired();
            //modelBuilder.Entity<City>()
            //    .HasOne(x => x.Country)
            //    .WithMany(y => y.Cities)
            //    .HasForeignKey(x => x.CountryId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
            }

        }
    }
}
