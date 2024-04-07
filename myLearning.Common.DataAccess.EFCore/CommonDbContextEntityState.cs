using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using myLearning.Common.Entities;

namespace myLearning.Common.DataAccess.EFCore
{
    public class CommonDbContextEntityState : DbContext
    {


        public ContextSession? Session { get; set; }

        protected IConfiguration Configuration { get; set; }

        public CommonDbContextEntityState(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangedOnSuccess)
        {
            FillTrackingData();
            return base.SaveChanges(acceptAllChangedOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangedOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            FillTrackingData();
            return base.SaveChangesAsync(acceptAllChangedOnSuccess, cancellationToken);
        }


        private void FillTrackingData()
        {
            foreach (var item in ChangeTracker.Entries<BaseTrackableEntity>()
                .Where(item => item.State == EntityState.Added || item.State == EntityState.Modified))
            {
                FillTrackingData(item);
            }
        }

        protected void FillTrackingData(EntityEntry<BaseTrackableEntity> entry)
        {
            var now = DateTime.UtcNow;

            entry.Entity.UpdatedByUserId = Session.UserId;
            entry.Entity.LastUpdateDate = now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedByUserId = Session.UserId;
                entry.Entity.CreatedDate = now;
            }
            else
            {
                entry.Property(p => p.CreatedDate).IsModified = false;
                entry.Property(p => p.CreatedByUserId).IsModified = false;
            }
        }

    }
}
