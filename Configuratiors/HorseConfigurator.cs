
using EchoTrackV2.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EchoTrackV2.Configuratiors;

public class HorseConfigurator : IEntityTypeConfiguration<HorseRepository>
{
    public void Configure(EntityTypeBuilder<HorseRepository> builder)
    {
    }
}
