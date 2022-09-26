using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class UserFollowers
    {
        public int UserFollowersId { get; set; }
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public  User? Follower { get; set; } 
        public  User? User { get; set; } 
    }
}
