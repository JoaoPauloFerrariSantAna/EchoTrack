using EchoTrackV2.Interfaces;
using EchoTrackV2.Repositories;
namespace EchoTrackV2.Services;

public class HorseService
{
    private readonly IAnimal _repository;

    public HorseService(IAnimal _repository)
    {
        _repository = _repository;
    }

    public void Eat(int amount)
    {
        throw new NotImplementedException();
    }
}
