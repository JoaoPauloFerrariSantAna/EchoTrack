using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Services;

public class SheepService : IAnimalService<SheepRepository>
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

    public SheepRepository Delete(HorseRepository animal)
    {
        throw new NotImplementedException();
    }

    public bool Eat(double amountToFeed)
    {
        throw new NotImplementedException();
    }

    public List<SheepRepository> Get()
    {
        throw new NotImplementedException();
    }

    public SheepRepository GetById(int id)
    {
        throw new NotImplementedException();
    }

    public SheepRepository Post(HorseRepository animal)
    {
        throw new NotImplementedException();
    }

    public SheepRepository Put(HorseRepository animal)
    {
        throw new NotImplementedException();
    }
}
