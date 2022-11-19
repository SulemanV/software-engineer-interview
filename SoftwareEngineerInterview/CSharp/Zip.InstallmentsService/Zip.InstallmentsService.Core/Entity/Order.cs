namespace Zip.InstallmentsService.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public double OrderAmount { get; set; }
    }
}
