namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public class CreateClientResponseDto
    {
        public Guid Objectkey { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    }
}
