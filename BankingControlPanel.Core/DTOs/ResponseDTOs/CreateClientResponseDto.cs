using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public class CreateClientResponseDto
    {
        public Guid ClientObjectkey { get; set; }
        public bool IsSuccess { get; set; }
    }
}
