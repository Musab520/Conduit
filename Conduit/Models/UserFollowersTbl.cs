using System;
using System.Collections.Generic;

namespace Conduit.Models
{
    public partial class UserFollowersTbl
    {
        public int UserFollowersId { get; set; }
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual UserTbl Follower { get; set; } = null!;
        public virtual UserTbl User { get; set; } = null!;
    }
}
