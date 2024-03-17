using Application.Queries.Feed;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedApiController : ControllerBase
    {
        private readonly IFeedService _feedService;

        public FeedApiController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        [HttpGet("getcoords")]
        public async Task<ActionResult> GetCoordinates([FromQuery] GetCoordinatesByName query)
        {
            var placeCoordinates = await _feedService.GetPlaceCoordinates(query);
            return Ok(placeCoordinates);
        }
    }
}