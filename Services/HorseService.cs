using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Services;

public class HorseService // : IAnimalService<HorseRepository>
{
    private readonly IAnimalRepository _repository;

    public HorseService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public string SayHello()
    {
        return "banana";
    }

    public bool Defecate(int animalId)
    {
        throw new NotImplementedException();
    }

    public HorseRepository Delete(HorseRepository animal)
    {
        throw new NotImplementedException();
    }

    public bool Eat(double amountToFeed)
    {
        throw new NotImplementedException();
    }

    public List<HorseRepository> Get()
    {
        throw new NotImplementedException();
    }

    public HorseRepository GetById(int id)
    {
        throw new NotImplementedException();
    }

    public HorseRepository Post(HorseRepository animal)
    {
        throw new NotImplementedException();
    }

    public HorseRepository Put(HorseRepository animal)
    {
        throw new NotImplementedException();
    }
}
