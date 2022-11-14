using BankingControlPanel.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Guid ObjectKey { get; set; }
        public int PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string? ProfilePhoto { get; set; }
        public Sex Sex { get; set; }
        public Address Address { get; set; }
        public List<Account> Accounts { get; set; } = new();
    }
}
