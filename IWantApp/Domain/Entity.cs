namespace IWantApp.Domain;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public string EditedBy { get; set; } = null!;
    public DateTime EditedOn { get; set; }
}