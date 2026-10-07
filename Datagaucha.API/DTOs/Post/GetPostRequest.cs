namespace Datagaucha.API.DTOs.Post;

public class GetPostRequest
{
    public int currentPage { get; set; } = 1;
    public int pageSize { get; set; } = 12;
    public string orderBy { get; set; } = "createdAt";
    public string orderDirection { get; set; } = "desc";
    public string search { get; set; } = string.Empty;
}
