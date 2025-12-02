using Microsoft.AspNetCore.Mvc;
using EchoTrackV2.Data;
using EchoTrackV2.Repositories;
using EchoTrackV2.Checkers;

namespace EchoTrackV2.Controllers;

[ApiController()]
[Route("api/[controller]")]
public class WorkerController : ControllerBase
{
    private readonly DataContext _context;

    public WorkerController(DataContext context)
    {
        _context = context;
    }

    private IActionResult HandleClientError(int statusCode, string msg)
    {
        switch (statusCode)
        {
            case 404:
                return NotFound(new { msg });

            case 409:
                return Conflict(new { msg });

            case 400:
            default:
                return BadRequest(new { msg });
        }
    }

    private WorkerRepository FindWorker(int id)
    {
        return _context.Workers.ToList().Find(w => w.Id == id);
    }

    [HttpGet]
    public IActionResult GetWorkers()
    {
        return Ok(_context.Workers.ToList<WorkerRepository>());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetWorkerById(int id)
    {
        WorkerRepository? worker = this.FindWorker(id);

        if (!AnimalChecker.DoesItExists<WorkerRepository>(worker))
            return this.HandleClientError(404, "Could not find animal with id");

        return Ok(worker);
    }

    /* [HttpPost("{animalId:int}/eat")]
    public IActionResult FeedAnimal(int animalId, [FromBody] double amountToFeed)
    {
        HorseRepository horseToFeed = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(horseToFeed))
            return this.HandleClientError(404, "Animal does not exists");

        if (!horseToFeed.Eat(amountToFeed))
            // TODO: make better error handler
            return this.HandleClientError(400, "Animal may be already full");

        return Ok(new { horseToFeed.Id, horseToFeed.Name, horseToFeed.AmountEaten });
    }*/

    [HttpPut("{workerId:int}")]
    public IActionResult PutAnimal(int workerId, [FromBody] WorkerRepository workerToPut)
    {
        WorkerRepository? existingWorker = null;

        if (!AnimalChecker.DoesItExists<WorkerRepository>(workerToPut))
            return this.HandleClientError(400, "something went wrong");

        existingWorker = _context.Workers.FirstOrDefault<WorkerRepository>(a => a.Id == workerId);

        if (!AnimalChecker.DoesItExists<WorkerRepository>(existingWorker))
            return this.HandleClientError(400, "something went wrong");

        _context.Entry<WorkerRepository>(existingWorker).CurrentValues.SetValues(workerToPut);
        _context.SaveChanges();

        // https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Reference/Methods/PUT
        return CreatedAtAction(nameof(GetWorkers), new { workerToPut.Id, workerToPut.Name });
    }

    // NOTE: maybe make a Patch here

    [HttpDelete("{workerId:int}")]
    public IActionResult DeleteAnimal(int workerId)
    {
        WorkerRepository? workerToDelete = this.FindWorker(workerId);

        if (!AnimalChecker.DoesItExists<WorkerRepository>(workerToDelete))
            return this.HandleClientError(404, "animal not found");

        _context.Workers.Remove(workerToDelete);
        _context.SaveChanges();

        return Ok(workerToDelete);
    }
}
