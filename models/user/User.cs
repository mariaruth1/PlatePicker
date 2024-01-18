namespace models.user;

public abstract class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}