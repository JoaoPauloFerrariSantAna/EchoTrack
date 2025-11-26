namespace EchoTrackV2.Interfaces;

public interface IWorkerRepository
{
    public void TakeCareOfAnimal(IAnimalRepository animalToCare);
}
