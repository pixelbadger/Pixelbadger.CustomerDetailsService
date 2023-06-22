using AutoMapper;
using CustomerDetailsService.Model;
using Microsoft.Extensions.Logging;
using Pixelbadger.CustomerDetailsService.Core.Dtos;
using Pixelbadger.CustomerDetailsService.Core.Model;
using Pixelbadger.CustomerDetailsService.Core.Repository;

namespace Pixelbadger.CustomerDetailsService.Core.Commands
{
    internal class CustomerDetailsCommandHandler : ICustomerDetailsCommandHandler
    {
        private readonly ICustomerDetailsRepository _customerDetailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerDetailsCommandHandler> _logger;

        public CustomerDetailsCommandHandler(ICustomerDetailsRepository customerDetailsRepository, IMapper mapper, ILogger<CustomerDetailsCommandHandler> logger)
        {
            _customerDetailsRepository = customerDetailsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Apply(CustomerDetailsCommands.CreateCustomerDetails command)
        {
            var customerDetails = _mapper.Map<CustomerDetails>(command.CustomerDetails);
            await _customerDetailsRepository.InsertCustomerDetails(customerDetails);
            await _customerDetailsRepository.PersistChanges();
            return customerDetails.Id;
        }

        public async Task Apply(CustomerDetailsCommands.DeleteCustomerDetails command)
        {
            await _customerDetailsRepository.DeleteCustomerDetails(command.CustomerDetailsId);
            await _customerDetailsRepository.PersistChanges();
        }

        public async Task Apply(CustomerDetailsCommands.UpdateCustomerDetails command)
        {
            var customerDetails = await _customerDetailsRepository.GetCustomerDetails(command.CustomerDetailsId);

            customerDetails.Name = command.CustomerDetails.Name;
            customerDetails.Email = command.CustomerDetails.Email;

            foreach (var address in command.CustomerDetails.Addresses)
            {
                if (address.Id == 0)
                {
                    var newAddress = _mapper.Map<Address>(address);
                    customerDetails.Addresses.Add(newAddress);
                    continue;
                }

                var currentAddress = customerDetails.Addresses.SingleOrDefault(a => a.Id == address.Id);
                if (currentAddress != null) _mapper.Map(address, currentAddress);
            }

            await _customerDetailsRepository.UpdateCustomerDetails(customerDetails);
            await _customerDetailsRepository.PersistChanges();
        }

        public async Task<CustomerDetailsResponseDto> Apply(CustomerDetailsCommands.GetCustomerDetails command)
        {
            var customerDetails = await _customerDetailsRepository.GetCustomerDetails(command.CustomerDetailsId);
            return _mapper.Map<CustomerDetailsResponseDto>(customerDetails);
        }

        public async Task<IEnumerable<CustomerDetailsResponseDto>> Apply(CustomerDetailsCommands.ListCustomerDetails command)
        {
            var customerDetails = await _customerDetailsRepository.GetAllCustomerDetails();
            return _mapper.Map<IEnumerable<CustomerDetailsResponseDto>>(customerDetails);
        }
    }
}
