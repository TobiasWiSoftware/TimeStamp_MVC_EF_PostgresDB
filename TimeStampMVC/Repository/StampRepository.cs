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
            _context.Stamps.Add(stamp);
            await _context.SaveChangesAsync();
        }

        public async Task<StampModel?> GetStampAsync(string id)
        {
            return await _context.Stamps.FirstOrDefaultAsync(s => s.Id.ToString() == id);
        }

        public async Task<StampModel?> GetLastStamp(CardModel card)
        {
            return await _context.Stamps.Where(s => s.Card != null && s.Card.Id == card.Id).OrderByDescending(s => s.TimeStamp).FirstOrDefaultAsync();
        }



    }

}
