using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string? ArticleTitle { get; set; } = "Untitled";
        public string? ArticleBody { get; set; } = "";
        public DateTime date { get; set; }  
        public User? User { get; set; }
        public ICollection<Comment>? comments { get; set; }
    }
}
