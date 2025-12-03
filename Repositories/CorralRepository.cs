using EchoTrackV2.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EchoTrackV2.Repositories;

[Table("CorralsTable")]
public class CorralRepository
{
    public int CorralId { get; set; }
    public int AnimalId { get; set; }

    public List<HorseRepository> Horses = new List<HorseRepository>();

    public List<SheepRepository> Sheeps = new List<SheepRepository>();
}
