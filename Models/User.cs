public class User
{
  public Guid UserId { get; set; }
  public required string Name { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public string Address { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;
  public bool IsAdmin { get; set; }
  public bool IsBanned { get; set; }
  public DateTime CreatedAt { get; set; }
}