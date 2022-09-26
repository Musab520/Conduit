using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class ArticleTbl
    {
        public ArticleTbl()
        {
            CommentTbls = new HashSet<CommentTbl>();
            FavoriteArticlesTbls = new HashSet<FavoriteArticlesTbl>();
            UserArticlesTbls = new HashSet<UserArticlesTbl>();
        }

        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string? ArticleTitle { get; set; }
        public string? ArticleBody { get; set; }

        public virtual UserTbl User { get; set; } = null!;
        public virtual ICollection<CommentTbl> CommentTbls { get; set; }
        public virtual ICollection<FavoriteArticlesTbl> FavoriteArticlesTbls { get; set; }
        public virtual ICollection<UserArticlesTbl> UserArticlesTbls { get; set; }
    }
}
