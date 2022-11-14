using BankingControlPanel.Core.Enums;

namespace BankingControlPanel.Core.DTOs.RequestDTOs
{
    public class GetClientsRequestDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchByName { get; set; }
        public string? SearchByPersonalID { get; set; }
        public string? SearchByEmail { get; set; }
        public ClientTableSortBy SortBy { get; set; }
        public string? SortDescending { get; set; }                                                                           
    }
}
