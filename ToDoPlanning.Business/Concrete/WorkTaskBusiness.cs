using System.Linq.Expressions;
using ToDoPlanning.Business.Abstract;
using ToDoPlanning.DataAccess.Abstract;
using ToDoPlanning.Entities.Concrete;

namespace ToDoPlanning.Business.Concrete
{
    public class WorkTaskBusiness : IWorkTaskBusiness
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public WorkTaskBusiness(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<WorkTask> GetById(int id)
        {
            return await _workTaskRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<WorkTask>> GetAll(Expression<Func<WorkTask, bool>> filter = null)
        {
            return await _workTaskRepository.GetAllAsync(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<WorkTask, bool>> filter = null)
        {
            return await _workTaskRepository.GetCountAsync(filter);
        }


        public void Create(WorkTask entity)
        {
            _workTaskRepository.Create(entity);
        }

        public void Delete(WorkTask entity)
        {
            _workTaskRepository.Delete(entity);
        }

        public void Update(WorkTask entity)
        {
            _workTaskRepository.Update(entity);
        }
    }
}
