using Microsoft.AspNetCore.Mvc;
using Pixelbadger.CustomerDetailsService.Core.Commands;
using Pixelbadger.CustomerDetailsService.Core.Dtos;
using static Pixelbadger.CustomerDetailsService.Core.Commands.CustomerDetailsCommands;

namespace CustomerDetailsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailsCommandHandler _commandHandler;
        private readonly ILogger<CustomerDetailsController> _logger;

        public CustomerDetailsController(ICustomerDetailsCommandHandler commandHandler, ILogger<CustomerDetailsController> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _commandHandler.Apply(new ListCustomerDetails());
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _commandHandler.Apply(new GetCustomerDetails(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostNew([FromBody] CreateOrUpdateCustomerDetailsDto dto)
        {
            var id = await _commandHandler.Apply(new CreateCustomerDetails(dto));
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUpdate(int id, [FromBody]CreateOrUpdateCustomerDetailsDto dto)
        {
            await _commandHandler.Apply(new UpdateCustomerDetails(id, dto));
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandHandler.Apply(new DeleteCustomerDetails(id)); 
            return Ok();
        }

    }
}