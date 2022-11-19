namespace Zip.InstallmentsService.Core.Dto
{
    public class CreateOrderDto
    {
        public Guid OrderId { get; set; }
        public double OrderAmount { get; set; }
        public int NumberOfInstallments { get; set; }
        public List<CreateOrderInstallmentsDto> Installments { get; set; } = new List<CreateOrderInstallmentsDto>();
    }

    public class CreateOrderInstallmentsDto
    {
        public Guid InstallmentId { get; set; }
        public DateTime DueDate { get; set; }
        public double InstallmentAmount { get; set; }
    }
}
