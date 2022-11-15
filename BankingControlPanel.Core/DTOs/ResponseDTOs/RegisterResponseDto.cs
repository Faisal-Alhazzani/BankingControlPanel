namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public  class RegisterResponseDto
    {
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
        public bool IsSuccess { get; set; }
    }
}
