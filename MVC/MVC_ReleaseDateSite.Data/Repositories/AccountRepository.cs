using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MVC_ReleaseDateSite.Interfaces;

namespace MVC_ReleaseDateSite.Data {
    public class AccountRepository {
        private readonly IAccountContext context;

        public AccountRepository(IAccountContext context) {
            this.context = context;
        }
        public void Add(IUser user) {
            context.Add(user);
        }

        public bool CheckLoginCredentials(IUser user) {
            return context.CheckLoginCredentials(user);
        }

        public IUser GetUserByName(string username) {
            return context.GetByPrimaryKey(username);
        }
    }
}
