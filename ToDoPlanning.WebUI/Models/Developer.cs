using ToDoPlanning.Entities.Concrete;

namespace ToDoPlanning.WebUI.Models
{
    public class Developer
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int DeveloperScore { get { return Level * 45; } }
        public int WorkScore { get; set; }
        public List<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();
    }
}
