using GodelTech.ReadMe.Example.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GodelTech.ReadMe.Example.Data.Configurations
{
    public class PrecipitationConfiguration : IEntityTypeConfiguration<Precipitation>
    {
        public void Configure(EntityTypeBuilder<Precipitation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Town).IsRequired();
            builder.Property(p => p.Temperature).IsRequired();
            builder.Property(p => p.DateTime).IsRequired();
            builder.Property(p => p.PrecipitationTypeId);
            builder.HasOne(x => x.PrecipitationType).WithMany().HasForeignKey(x => x.PrecipitationTypeId);
        }
    }
}