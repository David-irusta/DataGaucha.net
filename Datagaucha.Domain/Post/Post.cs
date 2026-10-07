using Datagaucha.Domain.Auth;

namespace Datagaucha.Domain.Post;

public class Post
{
    public long Id { get; set; }

    private string body = string.Empty;

    public string Body { get => body; set => body = value; }

    private Datagaucha.Domain.FileSystem.File? file;

    public virtual Datagaucha.Domain.FileSystem.File? File { get => file; set => file = value; }

    private User? user;

    public virtual User? User { get => user; set => user = value; }

    public string GetUserName()
    {
        if (this.User != null) return this.User.UserName;
        return "Usuario no encontrado";
    }

    public string? ImageUrl()
    {
        if (this.File != null) return this.File.ImageUrl();
        return null;
    }
}