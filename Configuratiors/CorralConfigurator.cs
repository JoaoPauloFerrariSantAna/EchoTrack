
using EchoTrackV2.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EchoTrackV2.Configuratiors;

public class CorralConfigurator : IEntityTypeConfiguration<CorralRepository>
{
    public void Configure(EntityTypeBuilder<CorralRepository> builder)
    {
    }
}
