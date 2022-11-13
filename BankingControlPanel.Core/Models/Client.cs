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
        public int NationalId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int MobileNo { get; set; }
        public string ProfilePhoto { get; set; } = string.Empty;
        public Gender Gender { get; set; }
    }
}
