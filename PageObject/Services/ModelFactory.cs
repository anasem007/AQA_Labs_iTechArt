using System.Collections.Generic;
using PageObject.Extensions;
using PageObject.Models;

namespace PageObject.Services
{
    public static class ModelFactory
    {
        public static List<Project> GenerateProjects()
        {
            DbConnectionFactory.CreateTransient("projects");
            return SqlService.ExecuteSql("select * from projects;").GetProjects();
        }
    }
}