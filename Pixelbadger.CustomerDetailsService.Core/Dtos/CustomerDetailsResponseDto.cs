using Pixelbadger.CustomerDetailsService.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixelbadger.CustomerDetailsService.Core.Dtos
{
    public record CustomerDetailsResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public List<AddressResponseDto> Addresses { get; set; } = new();
    }
}
