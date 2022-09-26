using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            ArticleTbls = new HashSet<ArticleTbl>();
            CommentTbls = new HashSet<CommentTbl>();
            FavoriteArticlesTbls = new HashSet<FavoriteArticlesTbl>();
            UserArticlesTbls = new HashSet<UserArticlesTbl>();
            UserFollowersTblFollowers = new HashSet<UserFollowersTbl>();
            UserFollowersTblUsers = new HashSet<UserFollowersTbl>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public virtual ICollection<ArticleTbl> ArticleTbls { get; set; }
        public virtual ICollection<CommentTbl> CommentTbls { get; set; }
        public virtual ICollection<FavoriteArticlesTbl> FavoriteArticlesTbls { get; set; }
        public virtual ICollection<UserArticlesTbl> UserArticlesTbls { get; set; }
        public virtual ICollection<UserFollowersTbl> UserFollowersTblFollowers { get; set; }
        public virtual ICollection<UserFollowersTbl> UserFollowersTblUsers { get; set; }
    }
}
