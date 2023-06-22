using Microsoft.AspNetCore.Mvc;
using Pixelbadger.CustomerDetailsService.Core.Commands;
using Pixelbadger.CustomerDetailsService.Core.Dtos;
using static Pixelbadger.CustomerDetailsService.Core.Commands.CustomerDetailsCommands;

namespace Pixelbadger.CustomerDetailsService.Api.Controllers
{
    /// <summary>
    /// API for performing CRUD operations on customer details
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailsCommandHandler _commandHandler;
        private readonly ILogger<CustomerDetailsController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commandHandler">Command handler</param>
        /// <param name="logger">Logger class</param>
        public CustomerDetailsController(ICustomerDetailsCommandHandler commandHandler, ILogger<CustomerDetailsController> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of all customer details
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _commandHandler.Apply(new ListCustomerDetails());
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific customer details entity by ID
        /// </summary>
        /// <param name="id">The ID of the customer details to be retrieved</param>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _commandHandler.Apply(new GetCustomerDetails(id));
            return Ok(response);
        }

        /// <summary>
        /// Creates a new customer details entity from the supplied DTO
        /// </summary>
        /// <param name="dto">A create/update customer details request DTO</param>
        /// <returns>The ID of the created entity</returns>
        [HttpPost]
        public async Task<IActionResult> PostNew([FromBody] CreateOrUpdateCustomerDetailsDto dto)
        {
            var id = await _commandHandler.Apply(new CreateCustomerDetails(dto));
            return Ok(id);
        }

        /// <summary>
        /// Updates an existing customer details entity by ID
        /// </summary>
        /// <param name="id">The ID of the customer details entity to be updated</param>
        /// <param name="dto">A create/update customer details request DTO</param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUpdate(int id, [FromBody] CreateOrUpdateCustomerDetailsDto dto)
        {
            await _commandHandler.Apply(new UpdateCustomerDetails(id, dto));
            return Ok();
        }

        /// <summary>
        /// Deletes an existing customer details entity
        /// </summary>
        /// <param name="id">The ID of the customer details entity to be deleted</param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandHandler.Apply(new DeleteCustomerDetails(id));
            return Ok();
        }

    }
}