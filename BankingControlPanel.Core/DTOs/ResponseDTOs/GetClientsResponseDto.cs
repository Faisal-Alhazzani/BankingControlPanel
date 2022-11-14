using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public class GetClientsResponseDto
    {
        public IEnumerable<ClientResponseDto> Clients { get; set; } = Enumerable.Empty<ClientResponseDto>();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalClients { get; set; }
    }
}
