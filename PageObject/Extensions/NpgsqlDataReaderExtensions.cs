using System.Collections.Generic;
using Npgsql;
using PageObject.Models;

namespace PageObject.Extensions
{
    public static class NpgsqlDataReaderExtensions
    {
        public static List<Project> GetProjects(this NpgsqlDataReader model)
        {
            var projects = new List<Project>();

            while (model.Read())
            {
                var project = new Project
                {
                    Name = model.GetString(0),
                    ModeSuite = model.GetString(3)
                };
                projects.Add(project);
            }
            return projects;
        }
    }
}