using EchoTrackV2.Repositories;

namespace EchoTrackV2.Interfaces;

public interface IAnimalRepository
{
    public List<IAnimalRepository> GetAnimals();
    public IAnimalRepository GetAnimalById(int id);
    public IAnimalRepository StoreAnimal(IAnimalRepository animal);
    public IAnimalRepository UpdateAnimal(IAnimalRepository animal);

    public bool Eat(double amountToFeed);
    public bool Defecate();
}
