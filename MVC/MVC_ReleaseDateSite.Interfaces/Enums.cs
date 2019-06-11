using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public enum FollowState {
        Following,
        NotFollowing
    }

    public enum SearchZones {
        Title,
        Description,
        Comments,
        Category
    }

    public enum SqlErrorCodes {
        InsertRolledback = 3609
    }
}
