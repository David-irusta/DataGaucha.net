public class CreateUserRequest
{
    public string userName { get; set; } = "";

    public string password { get; set; } = "";

    public IFormFile? file { get; set; }
}