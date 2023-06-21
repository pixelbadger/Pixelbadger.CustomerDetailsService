using CustomerDetailsService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixelbadger.CustomerDetailsService.Core.Repository
{
    /// <summary>
    /// Defines a contract for a an implementation
    /// </summary>
    public interface ICustomerDetailsRepository
    {
        public Task InsertCustomerDetails(CustomerDetails customerDetails); 
        public Task UpdateCustomerDetails(CustomerDetails customerDetails);
        public Task DeleteCustomerDetails(int customerDetailsId);
        public Task<CustomerDetails> GetCustomerDetails(int customerDetailsId);
        /// <summary>
        /// Retrieves all customer details entities
        /// </summary>
        /// <remarks>
        /// Almost certainly some scaling issues arising from this approach.
        /// A production-level implementation would implement pagination, 
        /// and likely not be part of the repository implementation.
        /// </remarks>
        /// <returns>A collection of all customer details entities</returns>
        public Task<IEnumerable<CustomerDetails>> GetAllCustomerDetails();
        /// <summary>
        /// Persists changes to the underlying data store
        /// </summary>
        /// <remarks>
        /// Typically I would use a corresponding unit of work pattern to orchestrate changes within a transaction.
        /// Given the brevity of the exercise this has been replaced with this method.
        /// </remarks>
        public Task PersistChanges(CancellationToken cancellationToken = default);
    }
}
