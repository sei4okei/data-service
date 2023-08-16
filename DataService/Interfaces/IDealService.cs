using DataService.Models;

namespace DataService.Interfaces
{
    public interface IDealService
    {
        Task<IEnumerable<Deal>> GetAll();
        public Task<Deal> GetByIdNoTracking(int id);
        Task<Deal> GetById(int id);
        bool Add(Deal deal);
        bool Update(Deal deal);
        bool Delete(Deal deal);
        bool Save();
    }
}
