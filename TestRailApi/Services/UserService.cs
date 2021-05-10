using System.Linq;
using OpenQA.Selenium;
using TestRailApi.Helpers;
using TestRailApi.Models.User;

namespace TestRailApi.Services
{
    public class UserService
    {
        public static User GetUser(string id)
        {
            foreach (var user in TestData.Users.Where(user => user.Id == id))
            {
                return user;
            }

            throw new NotFoundException();
        }
    }
}