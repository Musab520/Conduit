using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class FavoriteArticlesTbl
    {
        public int FavoriteArticlesId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public virtual ArticleTbl Article { get; set; } = null!;
        public virtual UserTbl User { get; set; } = null!;
    }
}
