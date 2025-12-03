using EchoTrackV2.Repositories;

namespace EchoTrackV2.Interfaces;

public interface IHorseService
{
    public List<HorseRepository> GetHorses();
    public HorseRepository GetHorseById(int id);
    public HorseRepository StoreHorse(HorseRepository horse);
}
