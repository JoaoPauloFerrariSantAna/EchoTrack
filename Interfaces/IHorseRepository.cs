using EchoTrackV2.Repositories;

namespace EchoTrackV2.Interfaces;

public interface IHorseRepository
{
    public List<HorseRepository> GetHorses();
    public HorseRepository GetHorseById(int id);
    public HorseRepository StoreHorse(HorseRepository animal);
    // public HorseRepository UpdateAnimal(HorseRepository animal);

    public bool Eat(double amountToFeed);
    public bool Defecate();
}
