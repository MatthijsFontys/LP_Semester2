using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVC_ReleaseDateSite.Logic;
using MVC_ReleaseDateSite.Data;
using MVC_ReleaseDateSite.Interfaces;

namespace UnitTests.MockContexts {
    public class AccountIconGeneration {
        AccountLogic accountLogic;
        public AccountIconGeneration() {
            accountLogic = new AccountLogic(
                    new AccountRepository(
                        new AccountMockContext()));
        }

        [Fact]
        public void GenerateIconForNewAccount() {
            // Assign
            string expected = @"https://via.placeholder.com/50/000000/?text=A";
            string actual = "";
            User user = new User
            {
                Username = "Amano",
                PasswordHash = "password" 
            };
            // Act
           accountLogic.Add(user);
           actual = actual + user.ImgLocation.Substring(0, 31) + user.ImgLocation.Substring(38);
           // Assert
           Assert.Equal(expected, actual);
        }

    }
}
