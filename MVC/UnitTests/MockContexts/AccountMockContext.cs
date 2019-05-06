using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Interfaces;

namespace UnitTests.MockContexts {
    class AccountMockContext : IAccountContext {
        public void Add(IUser type) {
            Console.WriteLine("Added user");
        }

        public bool CheckLoginCredentials(IUser user) {
            throw new NotImplementedException();
        }

        public void Delete<T2>(T2 primaryKey) {
            throw new NotImplementedException();
        }

        public List<IUser> GetAll() {
            throw new NotImplementedException();
        }

        public IUser GetByPrimaryKey<T2>(T2 id) {
            throw new NotImplementedException();
        }

        public void Update(IUser type) {
            throw new NotImplementedException();
        }
    }
}
