using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Data;

namespace UnitTests {
    class CategoryMockContext : ICategoryContext {
        public IEnumerable<string> GetAllCategories() {
            throw new NotImplementedException();
        }
    }
}
