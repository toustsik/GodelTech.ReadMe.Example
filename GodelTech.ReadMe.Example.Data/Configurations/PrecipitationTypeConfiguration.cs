using GodelTech.ReadMe.Example.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GodelTech.ReadMe.Example.Data.Configurations
{
    public class PrecipitationTypeConfiguration : IEntityTypeConfiguration<PrecipitationType>

    {
        public void Configure(EntityTypeBuilder<PrecipitationType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}