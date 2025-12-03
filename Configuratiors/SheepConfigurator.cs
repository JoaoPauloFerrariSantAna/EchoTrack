
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Configuratiors;

public class SheepConfigurator : IEntityTypeConfiguration<SheepRepository>
{
    public void Configure(EntityTypeBuilder<SheepRepository> builder)
    {
    }
}
