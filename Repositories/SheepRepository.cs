using EchoTrackV2.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EchoTrackV2.Repositories;

public class SheepRepository : IAnimalRepository
{
    [Editable(false)]
    public int Id { get; set; }

    [Length(5, 12, ErrorMessage = "name must have 5 or 12 letters")]
    [Editable(true)]
    public string Name { get; set; }

    public bool Eat(double amountToFeed)
    {
        throw new NotImplementedException();
    }

    public bool Defecate()
    {
        throw new NotImplementedException();
    }
}