using Datagaucha.Domain.FileSystem;
using System.Security.Cryptography;
using System.Text;

namespace Datagaucha.Domain.Auth;

public class User
{
    private long id;

    public long Id { get => id; set => id = value; }

    private string userName = "";

    public string UserName { get => userName; set => userName = value; }

    private string password = "";

    private string Password { get => password; set => password = value; }

    private Image? image = null;

    public virtual Image? Image { get => image; set => image = value; }

    private static string encrypt(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] byteHash = SHA1.HashData(bytes);

	    return Convert.ToBase64String(byteHash);
    }

    public virtual void SetPassword(string password)
    {
	    this.password = User.encrypt(password);
    }

    public virtual bool IsPassword(string password)
    {
	    string  encryptedPassword= User.encrypt(password);
	    if (this.password == encryptedPassword)
	    {
		    return true;
	    }

	    return false;
    }

    public string? GetAvatarurl()
    {
        if (this.Image != null)
        {
            return "image/" + this.Image.Id;
        }

        return null;
    }
}