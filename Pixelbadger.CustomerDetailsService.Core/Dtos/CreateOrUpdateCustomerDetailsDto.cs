using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixelbadger.CustomerDetailsService.Core.Dtos
{
    public record CreateOrUpdateCustomerDetailsDto
    {
        [Required]
        public string Name { get; init; } = string.Empty;
        [Required]
        public string Email { get; init; } = string.Empty;
        [Required]
        public List<CreateOrUpdateCustomerAddressDto> Addresses { get; set; } = new();
    }
}
