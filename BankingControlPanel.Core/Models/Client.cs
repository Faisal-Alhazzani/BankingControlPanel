using BankingControlPanel.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingControlPanel.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid ObjectKey { get; set; }
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string? ProfilePhoto { get; set; }
        public Sex Sex { get; set; }
        public Address Address { get; set; }
        public List<Account> Accounts { get; set; } = new();
    }
}
