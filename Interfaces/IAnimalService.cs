using EchoTrackV2.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EchoTrackV2.Interfaces;

public interface IAnimalService<TRepostory> where TRepostory : class
{
    public List<TRepostory> GetAnimals();
    public TRepostory GetById(int id);
    public TRepostory Post(TRepostory animal);
    public TRepostory Put(TRepostory animal);
    public TRepostory Delete(TRepostory animal);
    public bool Eat(double amountToFeed);
    public bool Defecate(int animalId);
}
