namespace GiaPha_Domain.Entities;

public class Doi
{
    public Guid Id { get; private set; }
    public int SoDoi { get; private set; }
    public string TenDoi { get; private set; } = null!;

    public Guid HoId { get; set; }
    public Ho Ho { get; set; } = null!;

    private Doi() { }

    public static Doi Create(int soDoi, string tenDoi, Guid hoId)
    {
        return new Doi
        {
            Id = Guid.NewGuid(),
            SoDoi = soDoi,
            TenDoi = tenDoi,
            HoId = hoId
        };
    }
}
