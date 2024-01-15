using BuildingBETA_Api.Models;
using BuildingBETA_Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildingBETA_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
 
        // GET: api/<BuildingController>
        [HttpGet("all-building")]
        public ActionResult<List<Building>> Get()
        {
            return buildingService.Get();
        }

        
        // GET api/<BuildingController>/5
        [HttpGet("building")]
        public ActionResult<Building> Get(string id)
        {
            var building = buildingService.Get(id); 
            if (building == null)
            {
                return NotFound($"building with Id = {id} not found");
            }

            return building;
        }

        // POST api/<BuildingController>
        [HttpPost("add-building")]
        public ActionResult<Building> Post([FromBody] Building building)
        {
            buildingService.Create(building);

            return CreatedAtAction(nameof(Get), new { id = building.Id}, building);
        }

        // PUT api/<BuildingController>/5
        [HttpPut("update-building")]
        public ActionResult Put(string id, [FromBody] Building building)
        {
            var existingBuilding = buildingService.Get(id);
            if (existingBuilding == null)
            {
                return NotFound($"building with Id = {id} not found");
            }

            buildingService.Update(building, id);

            return NoContent();
        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("remove-building")]
        public ActionResult Delete(string id)
        {
            var building = buildingService.Get(id);
            if (building == null)
            {
                return NotFound($"building with Id = {id} not found");
            }

            buildingService.Delete(id);

            return Ok($"building with Id = {id} was deleted");
        }
    }

 
}
