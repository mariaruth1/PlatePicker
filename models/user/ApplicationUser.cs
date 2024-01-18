namespace models.user;

public class ApplicationUser : User
{
    public List<Plate> CustomPlates { get; set; } = new List<Plate>();
}