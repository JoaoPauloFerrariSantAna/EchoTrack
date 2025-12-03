using EchoTrackV2.Interfaces;
using Microsoft.AspNetCore.Server.HttpSys;

namespace EchoTrackV2.Repositories;

public class WorkerRepository : IWorkerRepository
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void TakeCareOfAnimal(IHorseRepository animal)
    {
        throw new NotImplementedException();
    }
}
