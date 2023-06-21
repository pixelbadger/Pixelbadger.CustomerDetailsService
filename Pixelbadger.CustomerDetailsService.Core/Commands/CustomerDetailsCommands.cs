using Pixelbadger.CustomerDetailsService.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixelbadger.CustomerDetailsService.Core.Commands
{
    public class CustomerDetailsCommands
    {
        /// <summary>
        /// Creates a new customer details entity
        /// </summary>
        /// <param name="CustomerDetails">A DTO representing the customer details to be created</param>
        public record CreateCustomerDetails(CreateOrUpdateCustomerDetailsDto CustomerDetails);
        /// <summary>
        /// Updates an existing customer details entity
        /// </summary>
        /// <param name="CustomerDetails">A DTO representing the customer details to be created</param>
        /// <param name="CustomerDetailsId">The ID of the customer details entity to be updated</param>
        public record UpdateCustomerDetails(int CustomerDetailsId, CreateOrUpdateCustomerDetailsDto CustomerDetails);
        /// <summary>
        /// Deletes the specified customer details entity
        /// </summary>
        /// <param name="CustomerDetailsId">The ID of the customer details entity to be deleted</param>
        public record DeleteCustomerDetails(int CustomerDetailsId);
        /// <summary>
        /// Gets a specific customer details entity by ID
        /// </summary>
        /// <param name="CustomerDetailsId">The ID of the customer details entity to be fetched</param>
        public record GetCustomerDetails(int CustomerDetailsId);
        /// <summary>
        /// Lists all 
        /// </summary>
        public record ListCustomerDetails();
    }
}
