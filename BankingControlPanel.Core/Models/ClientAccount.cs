using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.Models
{
    public class ClientAccount
    {
        public Guid ObjectKey { get; set; }
        public virtual Client? Client { get; set; }
        public int ClientId { get; set; }
        public virtual Account? Account { get; set; }
        public int AccountId { get; set; }
    }
}
