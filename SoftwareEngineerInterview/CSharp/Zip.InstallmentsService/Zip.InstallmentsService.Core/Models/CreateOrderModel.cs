namespace Zip.InstallmentsService.Core.Models
{
    public class CreateOrderModel
    {
        public double Amount { get; set; }
        public int NumberOfInstallments { get; set; }
        public int FrequencyDays { get; set; }
    }
}
