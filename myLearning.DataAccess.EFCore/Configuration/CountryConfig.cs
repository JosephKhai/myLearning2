using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myLearning.Entities;

namespace myLearning.DataAccess.EFCore.Configuration
{
    public class CountryConfig : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {

            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ISO2).IsRequired();
            builder.Property(x => x.ISO3).IsRequired();

            builder
                .HasMany(x => x.Cities)
                .WithOne(c => c.Country)  // Assuming Cities has a navigation property called Countries
                .HasForeignKey(c => c.CountryId);  // Assuming Cities has a foreign key property called CountryId

        }
    }
}
