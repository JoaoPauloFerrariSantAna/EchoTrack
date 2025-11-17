namespace EchoTrackV2.Interfaces;

public interface IAnimalRepository
{
    public bool Eat(double amountToFeed);
    public bool Defecate();
}
