using EchoTrackV2.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EchoTrackV2.Repositories;

public class SheepRepository : IAnimalRepository
{
    [Editable(false)]
    public int Id { get; set; }

    [Length(5, 12, ErrorMessage = "name must have 5 or 12 letters")]
    [Editable(true)]
    public string Name { get; set; }

    public double AmountEaten { get; private set; } = 0;

    [DisallowNull]
    [Editable(false)]
    public double MaxAmountToEat { get; private set; } = 11.75;

    [DisallowNull]
    [Editable(false)]
    public bool IsFull { get; private set; } = false;

    private const double AmountToDefecate = 1.25;

    public bool Eat(double amountToFeed)
    {
        throw new NotImplementedException();
    }

    public bool Defecate()
    {
        throw new NotImplementedException();
    }

    public string SayHello()
    {
        return "Test message";
    }

    public List<IAnimalRepository> GetAnimals()
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository GetAnimalById(int id)
    {
        throw new NotImplementedException();
    }

    public SheepRepository StoreAnimal(SheepRepository animal)
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository UpdateAnimal(IAnimalRepository animal)
    {
        throw new NotImplementedException();
    }

    public IAnimalRepository StoreAnimal(IAnimalRepository animal)
    {
        throw new NotImplementedException();
    }
}