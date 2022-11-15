namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public class ClientResponseDto
    {
        public Guid ObjectKey { get; set; }
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string? ProfilePhoto { get; set; }
        public AddressResponseDto Address { get; set; }
        public IEnumerable<Guid> Accounts { get; set; } = Enumerable.Empty<Guid>();
    }
}
