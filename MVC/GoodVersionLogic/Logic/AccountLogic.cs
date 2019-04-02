using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ReleaseDateSite.Logic {
    public class AccountLogic {
        Random random;
        private AccountRepository accountRepository;
        public AccountLogic(AccountRepository accountRepository) {
            this.accountRepository = accountRepository;
            random = new Random();
    }
        public void Add(User user) {
            user.ImgLocation = GenerateStandardProfilePicture(user.Username);
            user.Salt = Encryptor.GenerateSalt();
            user.PasswordHash = Encryptor.Hash(user.PasswordHash + user.Salt);
            accountRepository.Add(user);
        }

        public bool CheckLoginCredentials(User user) {
            string salt = GetUserByName(user.Username).Salt;
            user.PasswordHash = Encryptor.Hash(user.PasswordHash + salt);
            return accountRepository.CheckLoginCredentials(user);
        }

        public User GetUserByName(string username) {
            return accountRepository.GetUserByName(username);
        }

        private string GenerateStandardProfilePicture(string username) {
            string[] colors = new string[] {
                "609dff", "60ff77", "b21c1c", "ededed", "fff13a"
            };
            string color = colors[random.Next(colors.Length)];
            return @"https://via.placeholder.com/50/" + color + @"/000000/?text=" + username;
        }
    }
}
