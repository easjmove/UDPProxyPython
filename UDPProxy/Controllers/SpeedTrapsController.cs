using Microsoft.AspNetCore.Mvc;
using UDPProxy.Managers;
using UDPProxy.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UDPProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeedTrapsController : ControllerBase
    {
        private SpeedTrapsManager _manager = new SpeedTrapsManager();

        // GET: api/SpeedTraps
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<SpeedTrap>> Get()
        {
            IEnumerable<SpeedTrap> result = _manager.GetAll();
            if (result == null || !result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }

        // POST api/SpeedTraps
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Post([FromBody] SpeedTrap newSpeedTrap)
        {
            SpeedTrap result = _manager.Add(newSpeedTrap);
            //No unique id, or getbyid method, so just references the getall
            return Created("api/SpeedTraps/", result);
        }
    }
}
