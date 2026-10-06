public class GetPostRequest
{
    int currentPage { get; set; }
    int pageSize { get; set; }
    string orderBy { get; set; }
    string orderDirection { get; set; }
    string search { get; set; }
}