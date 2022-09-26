using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class FavoriteArticles
    {
        public int FavoriteArticlesId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public Article? Article { get; set; } 
        public User? User { get; set; } 
    }
}
