namespace GiaPha_WebAPI.Controller.ControllerChiHo;
public class RequestChiHo
{
    public class CreateChiHoRequest
    {
        public Guid IdHo { get; set; }
        public string TenChiHo { get; set; } = null!;
        public string? MoTa { get; set; }
    }
    public class UpdateChiHoRequest
    {
        public Guid IdHo { get; set; }
        public string TenChiHo { get; set; } = null!;
        public string? MoTa { get; set; }
        public Guid? TruongChiId { get; set; }
    }
}