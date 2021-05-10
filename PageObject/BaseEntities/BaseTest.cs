using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Models;
using PageObject.Services;

namespace PageObject.BaseEntities
{
    public class BaseTest
    {
        public static readonly string BaseUrl = Configurator.BaseUrl;
        public Project Project;
        public IWebDriver Driver;
        protected WaitService WaitService;

        [SetUp]
        public void Setup()
        {
            Driver = new BrowserService().WebDriver;
            WaitService = new WaitService(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
          //  SetUpProject();
        }

        /*public void SetUpProject()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = Path.Combine(basePath, $"TestData{Path.DirectorySeparatorChar}", @"project.json");

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            /*Project project = new Project();
            project.Name = "Test Project";
            project.Type = ProjectType.SingleBaseline;
            
            Console.Out.WriteLine(JsonSerializer.Serialize(project));#1#

            var jsonStream = File.ReadAllText(fullPathToFile);
            var list = JsonSerializer.Deserialize<Project[]>(jsonStream);

            foreach (var project in list)
            {
                Project = project;
            }
        }*/
    }
}
