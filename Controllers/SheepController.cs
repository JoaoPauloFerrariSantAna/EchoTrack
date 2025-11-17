namespace EchoTrackV2.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using EchoTrackV2.Repositories;

[Route("api/animal/[controller]")]
[ApiController()]
public class SheepController : ControllerBase
{
    // TODO: substitute for a database
    private static List<SheepRepository> animals = new List<SheepRepository> { };

    private SheepRepository FindAnimal(int id)
    {
        return animals.Find(a => a.Id == id);
    }

    private bool DoesAnimalExists(SheepRepository animal)
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
        SheepRepository? animal = this.FindAnimal(animalId);

        if (!this.DoesAnimalExists(animal)) return NotFound(new { msg = "Could not find animal with id" });

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult PostAnimal([FromBody] SheepRepository animal)
    {
        if (!this.DoesAnimalExists(animal))
            return BadRequest(new { msg = "something went wrong" });

        if (animals.Any<SheepRepository>(a => a.Id == animal.Id))
            return Conflict(new { msg = "Animal with Id already exists" });

        animals.Add(animal);

        return CreatedAtAction(nameof(GetAnimal), new { Id = animal.Id }, animal);
    }

    [HttpPut("{animalId:int}")]
    public IActionResult PutAnimal(int animalId, [FromBody] SheepRepository animalToPut)
    {
        if (!this.DoesAnimalExists(animalToPut)) return BadRequest(new { msg = "something went wrong" });

        SheepRepository? existingAnimal = animals.FirstOrDefault(a => a.Id == animalToPut.Id);

        existingAnimal.Name = animalToPut.Name;

        // https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Reference/Methods/PUT
        return CreatedAtAction(nameof(GetAnimal), new { Id = animalToPut.Id });
    }

    // NOTE: maybe make a Patch here

    [HttpDelete("{animalId:int}")]
    public IActionResult DeleteAnimal(int animalId)
    {
        SheepRepository? animalToDelete = animals.Find(a => a.Id == animalId);

        if (this.DoesAnimalExists(animalToDelete)) return NotFound(new { msg = "animal with id not found" });

        animals.Remove(animalToDelete);

        return Ok(animalToDelete);
    }
}
