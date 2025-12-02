namespace EchoTrackV2.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using EchoTrackV2.Data;
using EchoTrackV2.Repositories;
using EchoTrackV2.Checkers;
using EchoTrackV2.Interfaces;

/// <summary>
///     Controller class for Horses (Services and Repositories
/// </summary>
[Route("api/animal/[controller]")]
[ApiController()]
public class SheepController : ControllerBase
{
    private readonly IAnimalRepository _repository;
    private readonly DataContext _context;

    /// <summary>
    ///     Public constructor of the controller
    /// </summary>
    /// <param name="repository">The repository of the controller</param>
    /// <param name="context">The context of your database</param>
    public SheepController(IAnimalRepository repository, DataContext context)
    {
        _repository = repository;
        _context = context;
    }


    /// <summary>
    ///     Handler to http erros
    /// </summary>
    /// <param name="statusCode">Http status code</param>
    /// <param name="msg">The message to return</param>
    /// <returns></returns>
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

    private SheepRepository FindAnimal(int id)
    {
        return _context.Sheep.ToList().Find(a => a.Id == id);
    }

    /// <summary>
    ///     Will get all animals from the database
    /// </summary>
    /// <returns>Http Ok</returns>
    [HttpGet]
    public IActionResult GetAnimal()
    {
        return Ok(_context.Sheep.ToList<SheepRepository>());
    }

    /// <summary>
    ///     Will get the animal by id
    /// </summary>
    /// <param name="animalId">the animal id</param>
    /// <returns>Http Not Found or Http Ok</returns>
    [HttpGet("{animalId:int}")]
    public IActionResult GetAnimalById(int animalId)
    {
        SheepRepository? animal = this.FindAnimal(animalId);

        if (!AnimalChecker.DoesItExists<SheepRepository>(animal))
            return this.HandleClientError(404, "Could not find animal with id");

        return Ok(animal);
    }

    /// <summary>
    ///     Handler to http post
    /// </summary>
    /// <param name="animal">the animal to add</param>
    /// <returns>Http bad request or Http created at</returns>
    [HttpPost]
    public IActionResult PostAnimal([FromBody] SheepRepository animal)
    {
        if (!AnimalChecker.DoesItExists<SheepRepository>(animal))
            return this.HandleClientError(400, "something went wrong");

        if (_context.Sheep.Any<SheepRepository>(a => a.Id == animal.Id))
            return this.HandleClientError(409, "Animal already exists");

        _context.Sheep.Add(animal);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAnimal), new { animal.Id }, animal);
    }

    /// <summary>
    ///     Handler of feeding the animal
    /// </summary>
    /// <param name="animalId">the id of the animal to feed</param>
    /// <param name="amountToFeed">the amount to feed the animal</param>
    /// <returns>Http not found, bad request or ok</returns>
    [HttpPost("{animalId:int}/eat")]
    public IActionResult FeedAnimal(int animalId, [FromBody] double amountToFeed)
    {
        SheepRepository animalToFeed = this.FindAnimal(animalId);

        if (!AnimalChecker.DoesItExists<SheepRepository>(animalToFeed))
            return this.HandleClientError(404, "Animal does not exists");

        if (!animalToFeed.Eat(amountToFeed))
            // TODO: make better error handler
            return this.HandleClientError(400, "Animal may be already full");

        return Ok(new { animalToFeed.Id, animalToFeed.Name, animalToFeed.AmountEaten });
    }

    /// <summary>
    ///     Handler to make the animal defecate
    /// </summary>
    /// <param name="animalId">the id of the animal to feed</param>
    /// <returns>Http not found, bad request or ok</returns>
    [HttpPost("{animalId:int}/defacate")]
    public IActionResult DefecateAnimal(int animalId)
    {
        SheepRepository horseToDefecate = this.FindAnimal(animalId);

        if (!AnimalChecker.DoesItExists<SheepRepository>(horseToDefecate))
            return this.HandleClientError(404, "Animal does not exists");

        if (!horseToDefecate.Defecate())
            return this.HandleClientError(400, "Animal has empty stomach");

        return Ok(new { horseToDefecate.Id, horseToDefecate.Name, horseToDefecate.AmountEaten });
    }

    /// <summary>
    ///     Handler to update animal info
    /// </summary>
    /// <param name="animalId">the id of the animal to feed</param>
    /// <param name="animalToPut">Animal data to update</param>
    /// <returns>http bad request or created at</returns>
    [HttpPut("{animalId:int}")]
    public IActionResult PutAnimal(int animalId, [FromBody] SheepRepository animalToPut)
    {
        SheepRepository? existingAnimal = null;

        if (!AnimalChecker.DoesItExists<SheepRepository>(animalToPut))
            return this.HandleClientError(400, "something went wrong");

        existingAnimal = _context.Sheep.FirstOrDefault<SheepRepository>(a => a.Id == animalId);

        if (!AnimalChecker.DoesItExists<SheepRepository>(existingAnimal))
            return this.HandleClientError(400, "something went wrong");

        _context.Entry<SheepRepository>(existingAnimal).CurrentValues.SetValues(animalToPut);
        _context.SaveChanges();

        // https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Reference/Methods/PUT
        return CreatedAtAction(nameof(GetAnimal), new { animalToPut.Id, animalToPut.Name });
    }

    // NOTE: maybe make a Patch here

    /// <summary>
    ///     Handler to delete animal
    /// </summary>
    /// <param name="animalId">the id of the animal to feed</param>
    /// <returns>Http not found or ok</returns>
    [HttpDelete("{animalId:int}")]
    public IActionResult DeleteAnimal(int animalId)
    {
        SheepRepository? animalToDelete = this.FindAnimal(animalId);

        if (!AnimalChecker.DoesItExists<SheepRepository>(animalToDelete))
            return this.HandleClientError(404, "animal not found");

        _context.Sheep.Remove(animalToDelete);
        _context.SaveChanges();

        return Ok(animalToDelete);
    }
}