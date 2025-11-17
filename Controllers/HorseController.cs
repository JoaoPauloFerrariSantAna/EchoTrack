namespace EchoTrackV2.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using EchoTrackV2.Repositories;

[Route("api/animal/[controller]")]
[ApiController()]
public class HorseController : ControllerBase
{
    // TODO: substitute for a database
    private static List<HorseRepository> animals = new List<HorseRepository> { };

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

    private HorseRepository FindAnimal(int id)
    {
        return animals.Find(a => a.Id == id);
    }

    private bool DoesAnimalExists(HorseRepository animal)
    {
        return (animal != null);
    }

    [HttpGet]
    public IActionResult GetAnimal()
    {
        return Ok(animals);
    }

    [HttpGet("{animalId:int}")]
    public IActionResult GetAnimalById(int animalId)
    {
        HorseRepository? animal = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(animal))
            return this.HandleClientError(404, "Could not find animal with id");

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult PostAnimal([FromBody] HorseRepository animal)
    {
        if (!this.DoesAnimalExists(animal))
            return this.HandleClientError(400, "something went wrong");

        if (animals.Any<HorseRepository>(a => a.Id == animal.Id))
            return this.HandleClientError(409, "Animal already exists");

        animals.Add(animal);

        return CreatedAtAction(nameof(GetAnimal), new { animal.Id }, animal);
    }

    [HttpPost("{animalId:int}")]
    public IActionResult FeedAnimal(int animalId, [FromBody] uint amountToFeed)
    {
        HorseRepository horseToFeed = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(horseToFeed))
            return this.HandleClientError(404, "Animal does not exists");

        if (!horseToFeed.Eat(amountToFeed))
        {
            // TODO: make better error handler
            return BadRequest(new { msg = "Animal may be already full" });
        }

        return Ok(new { horseToFeed.Id, horseToFeed.Name, horseToFeed.AmountEaten });
    }

    [HttpPut("{animalId:int}")]
    public IActionResult PutAnimal(int animalId, [FromBody] HorseRepository animalToPut)
    {
        if (!this.DoesAnimalExists(animalToPut)) 
            return this.HandleClientError(400, "something went wrong");

        HorseRepository? existingAnimal = animals.FirstOrDefault(a => a.Id == animalToPut.Id);

        existingAnimal.Name = animalToPut.Name;

        // https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Reference/Methods/PUT
        return CreatedAtAction(nameof(GetAnimal), new { animalToPut.Id });
    }

    // NOTE: maybe make a Patch here

    [HttpDelete("{animalId:int}")]
    public IActionResult DeleteAnimal(int animalId)
    {
        HorseRepository? animalToDelete = animals.Find(a => a.Id == animalId);

        if (this.DoesAnimalExists(animalToDelete))
            return this.HandleClientError(404, "animal not found");

        animals.Remove(animalToDelete);

        return Ok(animalToDelete);
    }
}
