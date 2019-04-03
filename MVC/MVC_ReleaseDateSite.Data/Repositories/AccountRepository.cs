using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Data {
    public class AccountRepository {
        private readonly IAccountContext context;

        public AccountRepository(IAccountContext context) {
            this.context = context;
        }
        public void Add(User user) {
            context.Add(user);
        }

        public bool CheckLoginCredentials(User user) {
            return context.CheckLoginCredentials(user);
        }

        public User GetUserByName(string username) {
            return context.GetByPrimaryKey(username);
        }
    }
}
