using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.IServices;
using Business_Logic_Layer.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                return Ok(await _eventService.GetAllEvents());
            }
            catch (Exception)
            {
                return BadRequest(CodeStatusConstant.WRONG_REQUEST);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            try
            {
                var data = await _eventService.GetEventById(id);
                if (data == null)
                {
                    return NotFound(CodeStatusConstant.INVALID_ID);
                }

                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(CodeStatusConstant.WRONG_REQUEST);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventModel eventModel)
        {
            try
            {
                await _eventService.AddEvent(eventModel);
                return Ok(CodeStatusConstant.CREATE_SUCCESS);
            }
            catch (Exception)
            {
                return BadRequest(CodeStatusConstant.WRONG_REQUEST);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventModel eventModel)
        {
            try
            {
                var data = await _eventService.GetEventById(id);
                if (data != null)
                {
                    await _eventService.UpdateEvent(id, eventModel);
                }
                else
                {
                    return BadRequest(CodeStatusConstant.WRONG_REQUEST);
                }

                return Ok(CodeStatusConstant.UPDATE_SUCCESS);
            }
            catch (Exception)
            {
                return BadRequest(CodeStatusConstant.WRONG_REQUEST);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var result = await _eventService.DeleteEvent(id);
                if (result != null)
                {
                    return Ok(CodeStatusConstant.DELETE_SUCCESS);
                }

                return BadRequest(CodeStatusConstant.WRONG_REQUEST);
            }
            catch (Exception)
            {
                return BadRequest(CodeStatusConstant.WRONG_REQUEST);
            }
        }
    }
}