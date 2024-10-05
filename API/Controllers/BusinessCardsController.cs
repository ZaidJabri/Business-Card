using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCardsController(IBusinessCardService _businessCardService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetBusinessCards()
        {
            var cards = await _businessCardService.GetAllBusinessCards();
            return Ok(cards);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessCard([FromBody] BusinessCardDto businessCardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCard = await _businessCardService.CreateBusinessCard(businessCardDto);
            return CreatedAtAction(nameof(GetBusinessCards), new { id = createdCard.Email }, createdCard);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessCard(int id)
        {
            var success = await _businessCardService.DeleteBusinessCard(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}