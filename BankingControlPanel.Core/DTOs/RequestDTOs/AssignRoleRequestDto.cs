using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.DTOs.RequestDTOs
{
    public class AssignRoleRequestDto
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
