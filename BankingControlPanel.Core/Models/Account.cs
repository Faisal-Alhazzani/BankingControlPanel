using System.ComponentModel.DataAnnotations.Schema;

namespace BankingControlPanel.Core.Models
{
    public class Account
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Guid ObjectKey { get; set; }
        public int ClientId { get; set; }
    }
}
