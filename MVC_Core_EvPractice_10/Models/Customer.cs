using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MVC_Core_EvPractice_10.Models
{
    public class Customer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [NotNull]
        public string CustomerName { get; set; }
        public DateTime BusinessStart { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal CreditLimit { get; set; }
        public string? CustomerType { get; set; }
        public string? Photo { get; set; }
        public virtual IList<DeliveryAddress> DeliveryAddresses { get; set; } = new List<DeliveryAddress>();
    }
}
