namespace Zip.InstallmentsService.Core.Entity
{
    public class Installment
    {
        public int Id { get; set; }
        public Guid InstallmentId { get; set; }
        public DateTime DueDate { get; set; }
        public double InstallmentAmount { get; set; }
        public Guid OrderId { get; set; }
    }
}
