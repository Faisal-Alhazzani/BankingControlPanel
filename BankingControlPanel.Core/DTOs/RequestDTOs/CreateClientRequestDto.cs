using BankingControlPanel.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.DTOs.RequestDTOs
{
    public class CreateClientRequestDto
    {
        [Description("Personal Id number, must be 11 characters length")]
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Description("Example value: +966555546135")]
        public string MobileNo { get; set; }
        public string? ProfilePhoto { get; set; }
        public Sex Sex { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}
