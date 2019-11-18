using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnotherPolicy")]

    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [EnableCors]        // Default policy.

        public List<Event> Get()
        {
            return _eventService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetEvent")]
        public ActionResult<Event> Get(string id)
        {
            var e = _eventService.Get(id);

            if (e == null)
            {
                return NotFound();
            }

            return e;
        }

       


        [HttpPost]
        public ActionResult<Event> Create(Event e
            )
        {
            _eventService.Create(e);

            return CreatedAtRoute("GetEvent", new { id = e.Id.ToString() }, e);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Event eventIn)
        {
            var e = _eventService.Get(id);

            if (e == null)
            {
                return NotFound();
            }

            _eventService.Update(id, eventIn);

            return NoContent();
        }


    }
   
}
