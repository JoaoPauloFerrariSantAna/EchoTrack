using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Services;

public class SheepService : ISheepService
{
    private readonly IHorseRepository _repository;

    public SheepService(IHorseRepository repository)
    {
        _repository = repository;
    }

    public bool Defecate(int animalId)
    {
        throw new NotImplementedException();
    }

    public List<SheepRepository> GetSheep()
    {
        throw new NotImplementedException();
    }

    public SheepRepository GetSheepById(int id)
    {
        throw new NotImplementedException();
    }
}
