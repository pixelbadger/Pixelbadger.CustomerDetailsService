using CustomerDetailsService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixelbadger.CustomerDetailsService.Core.Repository
{
    internal class EfCoreCustomerDetailsRepository : ICustomerDetailsRepository
    {
        private readonly CustomerDetailsContext _dbContext;
        private readonly ILogger<EfCoreCustomerDetailsRepository> _logger;

        public EfCoreCustomerDetailsRepository(CustomerDetailsContext dbContext, ILogger<EfCoreCustomerDetailsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task DeleteCustomerDetails(int customerDetailsId)
        {
            _logger.LogInformation($"Deleting customer details for ID '{customerDetailsId}'");

            var customerDetails = await _dbContext.FindAsync<CustomerDetails>(customerDetailsId) 
                ?? throw new ArgumentException("The specified customer details record could not be found", nameof(customerDetailsId));
            _dbContext.CustomerDetails.Remove(customerDetails);
        }

        public Task<IEnumerable<CustomerDetails>> GetAllCustomerDetails()
        {
            IEnumerable<CustomerDetails> list = _dbContext.CustomerDetails.Include(c => c.Addresses).ToList();
            return Task.FromResult(list);
        }

        public async Task<CustomerDetails> GetCustomerDetails(int customerDetailsId)
        {
            _logger.LogInformation($"Fetching customer details for ID '{customerDetailsId}'");

            var customerDetails = await _dbContext.FindAsync<CustomerDetails>(customerDetailsId)
                 ?? throw new ArgumentException("The specified customer details record could not be found", nameof(customerDetailsId));

            // explicitly load the addresses child collection
            _dbContext.Entry(customerDetails).Collection(c => c.Addresses).Load();

            return customerDetails;
        }

        public async Task InsertCustomerDetails(CustomerDetails customerDetails)
        {
            await _dbContext.CustomerDetails.AddAsync(customerDetails);
        }

        public async Task PersistChanges(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Persisting changes to database");
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateCustomerDetails(CustomerDetails customerDetails)
        {
            _dbContext.Entry(customerDetails).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
