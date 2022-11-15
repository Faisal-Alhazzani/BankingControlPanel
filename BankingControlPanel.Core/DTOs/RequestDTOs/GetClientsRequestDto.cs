using BankingControlPanel.Core.Enums;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankingControlPanel.Core.DTOs.RequestDTOs
{
    public class GetClientsRequestDto
    {
        [Description("Page default value is 1")]
        public int? Page { get; set; }
        [Description("Page size default value is 10")]
        public int? PageSize { get; set; }
        public string? SearchByName { get; set; } 
        public string? SearchByPersonalID { get; set; }
        public string? SearchByEmail { get; set; }
        [EnumDataType(typeof(ClientTableSortBy))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientTableSortBy? SortBy { get; set; }
        public bool SortDescending { get; set; }                                                                           
    }
}
