using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myLearning.Common.DataAccess.EFCore;
using myLearning.DataAccess.EFCore.Configuration;
using myLearning.Entities;

namespace myLearning.DataAccess.EFCore.DbContexts
{
    public class myLearningDbContexts : CommonDbContextEntityState
    {
        public myLearningDbContexts(DbContextOptions options, IConfiguration configuration) : base(options, configuration)
        {
        }

        public DbSet<Cities> Cities => Set<Cities>();
        public DbSet<Countries> Countries => Set<Countries>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EntityTypeConfiguration classes
            //modelBuilder.ApplyConfiguration(new CityConfig());
            //modelBuilder.ApplyConfiguration(new CountryConfig());


            ////OR Fluet API
            //modelBuilder.Entity<Cities>().ToTable("Cities");
            //modelBuilder.Entity<Cities>()
            //    .HasKey(x => x.Id);
            //modelBuilder.Entity<Cities>()
            //    .Property(x => x.Id).IsRequired();
            //modelBuilder.Entity<Cities>()
            //    .Property(x => x.Lat).HasColumnType("decimal(7,4)");
            //modelBuilder.Entity<Cities>()
            //    .Property(x => x.Lon).HasColumnType("decimal(7,4)");


            //modelBuilder.Entity<Countries>().ToTable("Countries");
            //modelBuilder.Entity<Countries>()
            //    .HasKey(x => x.Id);
            //modelBuilder.Entity<Countries>()
            //    .Property(x => x.Id).IsRequired();
            //modelBuilder.Entity<Cities>()
            //    .HasOne(x => x.Countries)
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
