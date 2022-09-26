using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class CommentTbl
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }
        public bool? IsAchild { get; set; }
        public string? BodyText { get; set; }

        public virtual ArticleTbl Article { get; set; } = null!;
        public virtual UserTbl User { get; set; } = null!;
    }
}
