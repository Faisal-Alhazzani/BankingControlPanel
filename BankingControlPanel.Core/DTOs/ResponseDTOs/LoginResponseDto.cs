namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public DateTime? ExpireDate { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    }
}
