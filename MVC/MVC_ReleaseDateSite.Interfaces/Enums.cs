using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Interfaces {
    public enum FollowState {
        following,
        notFollowing
    }

    // Todo: put these in the database instead
    public enum SearchZones {
        title,
        description,
        comments,
        category
    }

    public enum SqlErrorCodes {
        insertRolledback = 3609
    }
}
