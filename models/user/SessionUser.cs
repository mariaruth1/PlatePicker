namespace models.user;

public class SessionUser : User
{
    public List<Plate> LikedPlates { get; set; } = new List<Plate>();
    public List<Plate> DislikedPlates { get; set; } = new List<Plate>();
}