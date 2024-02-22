using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TimeStampLibary.Models;
using TimeStampMVC.Data;

namespace TimeStampMVC.Repository
{


    public class StampRepository : IStampRepository
    {
        private readonly ApplicationDbContext _context;

        public StampRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStampAsync(StampModel stamp)
        {
            _context.Stamp.Add(stamp);
            await _context.SaveChangesAsync();
        }

        public async Task<StampModel?> GetStampAsync(string id)
        {
            return await _context.Stamp.FirstOrDefaultAsync(s => s.Id.ToString() == id);
        }

        public async Task<StampModel?> GetLastStamp(int id)
        {
            return await _context.Stamp.Where(s => s.Id == id).OrderByDescending(s => s.TimeStamp).FirstOrDefaultAsync();
        }



    }

}
