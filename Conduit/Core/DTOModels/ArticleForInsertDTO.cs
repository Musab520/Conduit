namespace Conduit.Core.DTOModels
{
    public class ArticleForInsertDTO
    {
        public int UserId { get; set; }
        public string? ArticleTitle { get; set; } = "Untitled";
        public string? ArticleBody { get; set; } = "";
        public DateTime date { get; set; } = DateTime.Now;
    }
}
