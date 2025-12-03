using EchoTrackV2.Checkers;
using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Services;

public class HorseService : IAnimalService<IAnimalRepository>
{
    private readonly IAnimalRepository _repository;

    public HorseService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public bool Defecate(int animalId)
    {
        throw new NotImplementedException();
    }

    public List<IAnimalRepository> GetAnimals()
    {
        return _repository.GetAnimals();
    }

    public IAnimalRepository GetById(int id)
    {
        IAnimalRepository? animal = _repository.GetAnimalById(id);

        return animal;
    }

    public IAnimalRepository Post(IAnimalRepository animal)
    {
        IAnimalRepository postedAnimal = null;

        if (!ExistenseChecker.DoesItExists<IAnimalRepository>(animal))
            return null;

        postedAnimal = _repository.StoreAnimal(animal);

        return postedAnimal;
    }

    public IAnimalRepository Put(IAnimalRepository animal)
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

    /*public HorseRepository Delete(HorseRepository animal)
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
    }*/
}