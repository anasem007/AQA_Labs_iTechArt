
namespace TestRailApi.Models.Project
{
    public class ProjectRequestModel
    {
        public string Name { get; set; }
        public string Announcement { get; set; }
        public bool ShowAnnouncement { get; set; }
        public int SuiteMode { get; set; }
    }
}