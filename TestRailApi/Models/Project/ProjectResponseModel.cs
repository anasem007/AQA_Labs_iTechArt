
namespace TestRailApi.Models.Project
{
    public class ProjectResponseModel
    {
        public string Announcement { get; set; }
        public int? CompletedOn { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public bool ShowAnnouncement { get; set; }
        public int SuiteMode { get; set; }
        public string Url { get; set; }
    }
}