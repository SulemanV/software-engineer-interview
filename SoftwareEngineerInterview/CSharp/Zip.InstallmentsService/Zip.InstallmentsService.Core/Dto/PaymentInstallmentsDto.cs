namespace Zip.InstallmentsService.Core.Dto
{
    public class PaymentInstallmentsDto
    {
        public int PaymentId { get; set; }
        public decimal PuchaseAmount { get; set; }
        public int UserId { get; set; }
        public int NumberOfInstalments { get; set; }
        public List<InstallmentsDto> Instalments { get; set; } = new List<InstallmentsDto>();
    }

    public class InstallmentsDto
    {
        public int InstalmentId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
    }
}
