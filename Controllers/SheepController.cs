namespace EchoTrackV2.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using EchoTrackV2.Repositories;
using EchoTrackV2.Data;

[Route("api/animal/[controller]")]
[ApiController()]
public class SheepController : ControllerBase
{
    private readonly DataContext _context;

    public SheepController(DataContext context)
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

    private SheepRepository FindAnimal(int id)
    {
        return _context.Sheep.ToList().Find(a => a.Id == id);
    }

    private bool DoesAnimalExists(SheepRepository animal)
    {
        return (animal != null);
    }

    [HttpGet]
    public IActionResult GetAnimal()
    {
        return Ok(_context.Sheep.ToList<SheepRepository>());
    }

    [HttpGet("{animalId:int}")]
    public IActionResult GetAnimalById(int animalId)
    {
        SheepRepository? animal = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(animal))
            return this.HandleClientError(404, "Could not find animal with id");

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult PostAnimal([FromBody] SheepRepository animal)
    {
        if (!this.DoesAnimalExists(animal))
            return this.HandleClientError(400, "something went wrong");

        if (_context.Sheep.Any<SheepRepository>(a => a.Id == animal.Id))
            return this.HandleClientError(409, "Animal already exists");

        _context.Sheep.Add(animal);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAnimal), new { animal.Id }, animal);
    }

    [HttpPost("{animalId:int}/eat")]
    public IActionResult FeedAnimal(int animalId, [FromBody] double amountToFeed)
    {
        SheepRepository animalToFeed = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(animalToFeed))
            return this.HandleClientError(404, "Animal does not exists");

        if (!animalToFeed.Eat(amountToFeed))
            // TODO: make better error handler
            return this.HandleClientError(400, "Animal may be already full");

        return Ok(new { animalToFeed.Id, animalToFeed.Name, animalToFeed.AmountEaten });
    }

    [HttpPost("{animalId:int}/defacate")]
    public IActionResult DefecateAnimal(int animalId)
    {
        SheepRepository horseToDefecate = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(horseToDefecate))
            return this.HandleClientError(404, "Animal does not exists");

        if (!horseToDefecate.Defecate())
            return this.HandleClientError(400, "Animal has empty stomach");

        return Ok(new { horseToDefecate.Id, horseToDefecate.Name, horseToDefecate.AmountEaten });
    }

    [HttpPut("{animalId:int}")]
    public IActionResult PutAnimal(int animalId, [FromBody] SheepRepository animalToPut)
    {
        SheepRepository? existingAnimal = null;

        if (!this.DoesAnimalExists(animalToPut))
            return this.HandleClientError(400, "something went wrong");

        existingAnimal = _context.Sheep.FirstOrDefault<SheepRepository>(a => a.Id == animalId);

        if (!this.DoesAnimalExists(existingAnimal))
            return this.HandleClientError(400, "something went wrong");

        _context.Entry<SheepRepository>(existingAnimal).CurrentValues.SetValues(animalToPut);
        _context.SaveChanges();

        // https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Reference/Methods/PUT
        return CreatedAtAction(nameof(GetAnimal), new { animalToPut.Id, animalToPut.Name });
    }

    // NOTE: maybe make a Patch here

    [HttpDelete("{animalId:int}")]
    public IActionResult DeleteAnimal(int animalId)
    {
        SheepRepository? animalToDelete = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(animalToDelete))
            return this.HandleClientError(404, "animal not found");

        _context.Sheep.Remove(animalToDelete);
        _context.SaveChanges();

        return Ok(animalToDelete);
    }
}
