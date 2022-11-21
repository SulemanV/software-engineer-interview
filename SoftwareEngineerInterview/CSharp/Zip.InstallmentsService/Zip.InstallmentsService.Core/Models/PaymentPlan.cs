namespace Zip.InstallmentsService.Core.Models
{
    public class PaymentPlan
    {
        public int Id { get; set; }
        public decimal PurchaseAmount { get; set; }
        public int UserId { get; set; }
        public List<Instalment> Instalments { get; set; } = new List<Instalment>();
    }
}
