namespace Adres.Procurement.Domain.Entities;

public class ProcurementEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Budget { get; set; }
    public string Entity { get; set; }
    public string Item { get; set; }
    public float Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public string Supplier { get; set; }
    public IEnumerable<ProcurementFileEntity> Files { get; set; } = new List<ProcurementFileEntity>();
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ProcurementEntity()
    {
        Entity = string.Empty;
        Item = string.Empty;
        Supplier = string.Empty;
    }

    public ProcurementEntity(ProcurementInfo info)
    {
        Budget = info.Budget;
        Entity = info.Entity;
        Item = info.Item;
        Quantity = info.Quantity;
        UnitPrice = info.UnitPrice;
        TotalPrice = info.TotalPrice;
        Date = info.Date;
        Supplier = info.Supplier;
        Files = info.Files;
        IsActive = info.IsActive;
    }

    public record ProcurementInfo(
        decimal Budget,
        string Entity,
        string Item,
        float Quantity,
        decimal UnitPrice,
        decimal TotalPrice,
        DateTime Date,
        string Supplier,
        IEnumerable<ProcurementFileEntity> Files,
        bool IsActive
    );
}
