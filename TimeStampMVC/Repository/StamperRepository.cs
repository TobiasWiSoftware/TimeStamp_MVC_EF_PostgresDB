using TimeStampLibary.Models;
using TimeStampMVC.Data;

namespace TimeStampMVC.Repository
{
    public class StamperRepository : IStamperRepository
    {
        private readonly ApplicationDbContext _context;

        public StamperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public StamperModel AddStamper(StamperModel stamper)
        {
            _context.Stamper.Add(stamper);
            _context.SaveChanges();
            return stamper;
        }

        public StamperModel? DeleteStamper(int id)
        {
            var stamper = _context.Stamper.Find(id);
            if (stamper != null)
            {
                _context.Stamper.Remove(stamper);
                _context.SaveChanges();
            }
            return stamper;
        }

        public IEnumerable<StamperModel> GetAllStampers()
        {
            return _context.Stamper;
        }

        public StamperModel? GetStamper(int id)
        {
            return _context.Stamper.Find(id);
        }

        public StamperModel UpdateStamper(StamperModel stamper)
        {
            var stamperToUpdate = _context.Stamper.Attach(stamper);
            stamperToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return stamper;
        }
    }
}
