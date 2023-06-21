using Pixelbadger.CustomerDetailsService.Core.Model;

namespace CustomerDetailsService.Model
{
    /// <summary>
    /// Model class describing the details of a customer
    /// </summary>
    public class CustomerDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; } = new();
    }
}
