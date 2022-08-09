using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breakfast.Contracts.Breakfast;
using Breakfast.Models;
using Breakfast.Services.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace Breakfast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }
        [HttpPost("")]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new BreakfastModel(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );

            _breakfastService.CreateBreakfast(breakfast);

            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet
            );

            return CreatedAtAction(
                nameof(GetBreakfast),
                new { id = breakfast.Id },
                response
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            var breakfast = _breakfastService.GetBreakfast(id);

            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet
            );

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBreakfast(Guid id, UpdateBreakfastRequest request)
        {
            var breakfast = new BreakfastModel(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );

            _breakfastService.UpdateBreakfast(breakfast);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            _breakfastService.DeleteBreakfast(id);
            return Ok(id);
        }
    }
}