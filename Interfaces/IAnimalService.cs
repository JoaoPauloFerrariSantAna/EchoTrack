using EchoTrackV2.Repositories;

namespace EchoTrackV2.Interfaces;

public interface IAnimalService<TRepostory>
{
    public List<TRepostory> Get();
    public TRepostory GetById(int id);
    public TRepostory Post(HorseRepository animal);
    public TRepostory Put(HorseRepository animal);
    public TRepostory Delete(HorseRepository animal);
    public bool Eat(double amountToFeed);
    public bool Defecate(int animalId);
}
