using System;
using NUnit.Framework;
using PageObject.Models;
using PageObject.Services;

namespace PageObject.Tests
{
    public class SqlTest
    {
        [Test]
        public void ConnectionTest()
        {
            SqlService.OpenConnection();
            SqlService.DropTable("users");
            SqlService.CreateModelTable("users");
            
            var users = SqlService.ExecuteSql("select * from users limit 1;");
           
            while (users.Read())
            {
                var project = new Project()
                {
                    Name = users.GetString(1),
                    // Type = int.Parse(projectsDB.GetString(2))
                };
        
                  Console.Out.WriteLine(" {0} {1}", users.GetString(1), users.GetString(2));
            }
            
            SqlService.CloseConnection();
        }
    }
}