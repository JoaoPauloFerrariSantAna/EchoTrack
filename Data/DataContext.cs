using Microsoft.EntityFrameworkCore;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

    public DbSet<HorseRepository> Horses { get; set; }
    public DbSet<SheepRepository> Sheep { get; set; }
}
