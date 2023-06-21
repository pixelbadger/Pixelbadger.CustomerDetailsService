using System.ComponentModel.DataAnnotations;

namespace Pixelbadger.CustomerDetailsService.Core.Dtos
{
    public record CreateOrUpdateCustomerAddressDto
    {
        [Required]
        public string LineOne { get; set; } = string.Empty;
        public string LineTwo { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
