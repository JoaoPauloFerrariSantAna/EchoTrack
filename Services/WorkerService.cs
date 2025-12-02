using EchoTrackV2.Interfaces;

namespace EchoTrackV2.Services;

public class WorkerService
{
    private readonly IWorkerRepository _repository;

    public WorkerService(IWorkerRepository repository)
    {
        _repository = repository;
    }
}
