using ToDoPlanning.DataAccess.Abstract;
using ToDoPlanning.Entities.Concrete;

namespace ToDoPlanning.DataAccess.Concrete
{
    public class WorkTaskDal : GenericDal<WorkTask, AppDbContext>, IWorkTaskRepository
    {
    }
}
