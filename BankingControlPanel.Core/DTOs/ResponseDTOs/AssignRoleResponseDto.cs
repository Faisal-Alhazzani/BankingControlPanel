namespace BankingControlPanel.Core.DTOs.ResponseDTOs
{
    public class AssignRoleResponseDto
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();

    }
}
