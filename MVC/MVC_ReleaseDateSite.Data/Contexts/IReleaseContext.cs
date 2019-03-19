using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Models;

namespace MVC_ReleaseDateSite.Data {
    public interface IReleaseContext {
        List<Release> GetReleases();
        Release GetReleaseById(int id);
        bool AddRelease(Release release);
    }
}
