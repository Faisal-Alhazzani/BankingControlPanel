using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public  class RegisterResponseDto
    {
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
        public bool IsSuccess { get; set; }
    }
}
