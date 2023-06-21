using CustomerDetailsService.Model;
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
            return Task.FromResult((IEnumerable<CustomerDetails>)_dbContext.CustomerDetails.ToList());
        }

        public async Task<CustomerDetails> GetCustomerDetails(int customerDetailsId)
        {
            _logger.LogInformation($"Fetching customer details for ID '{customerDetailsId}'");

            return await _dbContext.CustomerDetails.FindAsync(customerDetailsId)
                ?? throw new ArgumentException("The specified customer details record could not be found", nameof(customerDetailsId));
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
            _dbContext.Entry(customerDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
