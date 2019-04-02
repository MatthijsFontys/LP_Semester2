using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MVC_ReleaseDateSite {
    internal static class SessionHolder {
        public const string SessionUserId = "_userId";
        public const string SessionUsername = "_userName";
        public const string SessionUserImg = "_userImg";
    }
}
