using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public class Article
    {

        public int ArticleId { get; set; }
        public string? ArticleTitle { get; set; } = "Untitled";
        public string? ArticleBody { get; set; } = "";
    }
}
