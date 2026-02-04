namespace GiaPha_WebAPI.Controller.ControllerHo;

public class RequestHo
{
    public class CreateHoRequest
    {
        public string TenHo { get; set; } = null!;
        public string? MoTa { get; set; }
        public string? queQuan { get; set; }
    }
    public class UpdateHoRequest
    {
        public string TenHo { get; set; } = null!;
        public string? MoTa { get; set; }
    }
}