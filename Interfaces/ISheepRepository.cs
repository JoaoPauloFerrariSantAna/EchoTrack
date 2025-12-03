using EchoTrackV2.Repositories;

namespace EchoTrackV2.Interfaces;

public interface ISheepRepository
{
    public List<SheepRepository> GetSheep();
    public SheepRepository GetSheepById(int id);
    public SheepRepository StoreSheep(SheepRepository animal);
    // public HorseRepository UpdateAnimal(HorseRepository animal);

    public bool Eat(double amountToFeed);
    public bool Defecate();
}
