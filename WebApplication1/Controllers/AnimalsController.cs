
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Data;


namespace WebApplication1.Controllers
{
    
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {


        private IDatabaseService _dbService;

        public AnimalsController(IDatabaseService service)
        {
            _dbService = service;
        }


        //  [HttpPost]
        //  public IActionResult CreateAnimlas(AnimalsController newAnimal)
        //   {
        //       return Ok();
        //    }
        [HttpGet]
       
        public IActionResult GetAnimlas(string orderBy)
        {
            return Ok(_dbService.GetAnimals(orderBy));
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal Cat)
        {
            return Ok(_dbService.AddAnimal(Cat));
        }


        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimal(int idAnimal, Animal newAnimal)
        {
            return Ok(_dbService.UpdateAnimal(idAnimal, newAnimal));
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {
            return Ok(_dbService.DeleteAnimal(idAnimal));
        }


    }
}
