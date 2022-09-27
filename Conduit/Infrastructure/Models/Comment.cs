using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }
        public bool? IsAchild { get; set; }
        public string? BodyText { get; set; }
        public Article? Article { get; set; }
        public User? User { get; set; }
    }
}
