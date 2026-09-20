using System.ComponentModel.DataAnnotations.Schema;

public class QueueParty
{
    public Guid Id { get; set; }
    public string Boss { get; set; } = null!;

    public int TargetSize { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Member> Members { get; set; }
}
