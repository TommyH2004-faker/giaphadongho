namespace GiaPha_Domain.Entities;

public class Ho
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string TenHo { get; private set; } = null!;
    public string? MoTa { get; private set; }
    // image of Ho could be added here in the future
    public string? HinhAnh { get; private set; }
    public ICollection<ChiHo> CacChiHo { get; private set; } = new List<ChiHo>();
    private Ho() { }
    public static Ho Create(string tenHo, string? moTa)
        {
            if (string.IsNullOrWhiteSpace(tenHo))
                throw new ArgumentException("TenHo cannot be empty", nameof(tenHo));

            return new Ho
            {
                Id = Guid.NewGuid(),
                TenHo = tenHo,
                MoTa = moTa,
            };
        } 
    public void Update(string tenHo, string? moTa)
        {
            if (string.IsNullOrWhiteSpace(tenHo))
                throw new ArgumentException("TenHo cannot be empty", nameof(tenHo));

            TenHo = tenHo;
            MoTa = moTa;
        }
   
}
