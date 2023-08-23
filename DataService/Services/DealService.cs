using DataService.Data;
using DataService.Interfaces;
using DataService.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService.Services
{
    public class DealService : IDealService
    {
        private readonly ApplicationContext context;

        public DealService(ApplicationContext _context)
        {
            context = _context;
        }
        public bool Add(Deal deal)
        {
            context.Deals.Add(deal);
            return Save();
        }

        public bool Delete(Deal deal)
        {
            context.Deals.Remove(deal);
            return Save();
        }

        public async Task<IEnumerable<Deal>> GetAll() => await context.Deals.ToListAsync();

        public async Task<Deal> GetById(int id) => await context.Deals.FirstOrDefaultAsync(d => d.Id == id);
        public async Task<Deal> GetByIdNoTracking(int id) => await context.Deals.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);

        public bool Save() => context.SaveChanges() > 0 ? true : false;

        public bool Update(Deal deal)
        {
            context.Deals.Update(deal);
            return Save();
        }
    }
}
