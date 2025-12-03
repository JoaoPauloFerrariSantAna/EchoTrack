using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Services;

public class SheepService : IAnimalService<IAnimalRepository>
{
    private readonly IAnimalRepository _repository;

    public SheepService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public bool Defecate(int animalId)
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository Delete(IAnimalRepository animal)
    {
        throw new NotImplementedException();
    }

    public bool Eat(double amountToFeed)
    {
        throw new NotImplementedException();
    }

    public List<IAnimalRepository> GetAnimals()
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository Post(IAnimalRepository animal)
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository Put(IAnimalRepository animal)
    {
        throw new NotImplementedException();
    }
}
