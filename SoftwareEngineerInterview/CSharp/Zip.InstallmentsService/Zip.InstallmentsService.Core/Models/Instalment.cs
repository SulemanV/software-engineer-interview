namespace Zip.InstallmentsService.Core.Models
{
    public class Instalment
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentPlan PaymentPlan { get; set; }
    }
}
