using EchoTrackV2.Interfaces;
using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EchoTrackV2.Repositories;

public class HorseRepository :  IAnimalRepository
{
    // TODO: add context

    [Editable(false)]
    public int Id { get; set; }

    [Length(5, 12, ErrorMessage = "name must have 5 or 12 letters")]
    [DisallowNull]
    [Editable(true)]
    public string Name { get; set; }

    [DisallowNull]
    [Editable(false)]
    public uint AmountEaten { get; private set; } = 0U;

    [DisallowNull]
    [Editable(false)]
    public double MaxAmountToEat { get; private set; } = 11.75;

    [DisallowNull]
    [Editable(false)]
    public bool IsFull { get; private set; } = false;

    public bool Eat(uint amountToFeed)
    {
        // it can't eat anymore
        if (IsFull) return false;

        // it can't eat negative values
        if (amountToFeed <= 0) return false;

        AmountEaten += amountToFeed;

        if (AmountEaten >= MaxAmountToEat) IsFull = true;

        return true;
    }

    public void Defecate()
    {
        throw new NotImplementedException();
    }
}
