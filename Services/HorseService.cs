using EchoTrackV2.Checkers;
using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;

namespace EchoTrackV2.Services;

public class HorseService : IHorseService
{
    private readonly IHorseRepository _repository;

    public HorseService(IHorseRepository repository)
    {
        _repository = repository;
    }

    public HorseRepository GetHorseById(int id)
    {
        return _repository.GetHorseById(id);
    }

    public List<HorseRepository> GetHorses()
    {
        return _repository.GetHorses();
    }

    public HorseRepository StoreHorse(HorseRepository horse)
    {
        HorseRepository postedHorse = _repository.GetHorseById(horse.Id);

        if (postedHorse != null)
            return null;

        return _repository.StoreHorse(horse);
    }
}