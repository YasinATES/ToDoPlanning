using System.Linq.Expressions;
using ToDoPlanning.Entities.Concrete;

namespace ToDoPlanning.Business.Abstract
{
    public interface IWorkTaskBusiness
    {
        Task<WorkTask> GetById(int id);
        Task<IEnumerable<WorkTask>> GetAll(Expression<Func<WorkTask, bool>> filter = null);
        Task<int> GetCountAsync(Expression<Func<WorkTask, bool>> filter = null);


        void Create(WorkTask entity);
        void Update(WorkTask entity);
        void Delete(WorkTask entity);
    }
}
