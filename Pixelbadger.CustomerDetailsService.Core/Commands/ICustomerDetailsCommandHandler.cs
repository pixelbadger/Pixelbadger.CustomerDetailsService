using Pixelbadger.CustomerDetailsService.Core.Dtos;

namespace Pixelbadger.CustomerDetailsService.Core.Commands
{
    public interface ICustomerDetailsCommandHandler
    {
        Task<int> Apply(CustomerDetailsCommands.CreateCustomerDetails command);
        Task Apply(CustomerDetailsCommands.DeleteCustomerDetails command);
        Task<CustomerDetailsResponseDto> Apply(CustomerDetailsCommands.GetCustomerDetails command);
        Task<IEnumerable<CustomerDetailsResponseDto>> Apply(CustomerDetailsCommands.ListCustomerDetails command);
        Task Apply(CustomerDetailsCommands.UpdateCustomerDetails command);
    }
}