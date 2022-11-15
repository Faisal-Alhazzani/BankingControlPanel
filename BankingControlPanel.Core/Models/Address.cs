using System.ComponentModel.DataAnnotations.Schema;

namespace BankingControlPanel.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid ObjectKey { get; set; }
        public int ClientId { get; set; }
        public string? Country { get; set; } 
        public string? City { get; set; } 
        public string? Street { get; set; }
        public string? ZipCode { get; set; } 
    }
}
