namespace Adres.Procurement.Domain.Entities;

public class ProcurementFileEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProcurementId { get; set; }
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public byte[] Content { get; set; } = null!;
    public long Size { get; set; }

    public ProcurementEntity Procurement { get; set; } = null!;
}
