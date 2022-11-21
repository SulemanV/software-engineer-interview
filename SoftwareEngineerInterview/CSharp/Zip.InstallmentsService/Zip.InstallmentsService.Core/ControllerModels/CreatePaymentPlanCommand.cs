namespace Zip.InstallmentsService.Core.ControllerModels
{
    public class CreatePaymentPlanCommand
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int Frequency { get; set; }
        public int NumberOfInstallments { get; set; }
    }
}
