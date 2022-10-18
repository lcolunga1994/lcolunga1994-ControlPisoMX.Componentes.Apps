namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Infrastructure.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ResidentialCoreSettingEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Setting>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Setting> builder)
        {
            builder.ToTable("Settings");

            builder.HasKey(e => e.Name);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .IsUnicode(false);

            builder.Property(e => e.Value)
                .IsRequired(true)
                .IsUnicode(false);
        }
    }
}