using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Core_EvPractice_10.Models
{
    public class DeliveryAddress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeliveryAddressId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
