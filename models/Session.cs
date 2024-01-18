using models.user;

namespace models;

public class Session
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public List<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
    public string Name { get; set; }
    public string SessionKey { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public List<Plate> SessionPlates { get; set; } = new List<Plate>();
    public Plate BestPlate { get; set; }
}