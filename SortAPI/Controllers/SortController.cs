using Microsoft.AspNetCore.Mvc;
using MediatR;
using SortAPI.Queries.GetNumbers;
using SortAPI.Commands.SortAndSaveNumbersCommand;

namespace SortAPI.Controllers
{
    [ApiController]
    [Route("SortedNumbers")]
    public class SortController : ControllerBase
    {
        private readonly ILogger<SortController> _logger;
        private readonly IMediator _mediator;

        public SortController(ILogger<SortController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator; 
        }

        [HttpGet(Name = "GetLatestNumbers")]
        public async Task<ActionResult<IEnumerable<int>>> Get()
        {
            var response = await _mediator.Send(new GetNumbersQuery());

            return Ok(response);
        }

        [HttpPost(Name = "SortAndSaveNumbers")]
        public async Task<IActionResult> Post(IEnumerable<int> numbers)
        {
            await _mediator.Send(new SortAndSaveNumbersCommand { Numbers = numbers});

            return Ok();
        }
    }
}