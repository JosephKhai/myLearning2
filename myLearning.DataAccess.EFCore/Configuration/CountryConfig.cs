using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myLearning.Entities;

namespace myLearning.DataAccess.EFCore.Configuration
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {

            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ISO2).IsRequired();
            builder.Property(x => x.ISO3).IsRequired();

            builder
                .HasMany(x => x.Cities)
                .WithOne(c => c.Country)  // Assuming City has a navigation property called Country
                .HasForeignKey(c => c.CountryId);  // Assuming City has a foreign key property called CountryId

        }
    }
}
