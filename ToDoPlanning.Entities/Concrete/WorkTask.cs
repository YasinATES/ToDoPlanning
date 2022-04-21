using ToDoPlanning.Entities.Helper;

namespace ToDoPlanning.Entities.Concrete
{
    public class WorkTask : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Duration { get; set; }
        public int Sprint { get; set; }
        public int WorkScore { get { return Level * Duration; } }
    }
}
