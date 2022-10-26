namespace Conduit.Core.DTOModels
{
    public class CommentForInsertDTO
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }
        public bool? IsAchild { get; set; }
        public string? BodyText { get; set; }
        public DateTime date { get; set; }
    }
}
