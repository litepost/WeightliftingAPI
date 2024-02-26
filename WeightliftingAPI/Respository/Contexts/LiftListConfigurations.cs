using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeightliftingAPI;

public class LiftListConfigurations : IEntityTypeConfiguration<Lift>
{
    public void Configure(EntityTypeBuilder<Lift> builder)
    {
        builder.HasKey(lift => lift.Id);
        builder.Property(lift => lift.Id).ValueGeneratedNever();
    }
}
