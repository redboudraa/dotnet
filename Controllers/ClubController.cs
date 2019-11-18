using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ClubService _clubService;

        public ClubController(ClubService clubService)
        {
            _clubService = clubService;
        }
        
        [HttpGet]
        public ActionResult<List<Club>> Get() =>
             _clubService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClub")]
        public ActionResult<Club> Get(string id)
        {
            var club = _clubService.Get(id);

            if (club == null)
            {
                return NotFound();
            }

            return club;
        }

        [HttpPost]
        public ActionResult<Club> Create(Club club
            )
        {
            _clubService.Create(club);

            return CreatedAtRoute("GetClub", new { id = club.Id.ToString() }, club);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string name, Club clubIn)
        {
            var club = _clubService.Get(name);

            if (club == null)
            {
                return NotFound();
            }

            _clubService.Update(name, clubIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var club = _clubService.Get(id);

            if (club == null)
            {
                return NotFound();
            }

            _clubService.Remove(club.Id);

            return NoContent();
        }
    }
}