namespace Pixelbadger.CustomerDetailsService.Core.Dtos
{
    public record AddressResponseDto
    {
        public int Id { get; set; }
        public string LineOne { get; set; } = string.Empty;
        public string LineTwo { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
