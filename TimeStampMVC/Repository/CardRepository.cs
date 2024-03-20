using TimeStampLibary.Models;
using TimeStampMVC.Data;

namespace TimeStampMVC.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCard(CardModel card)
        {
            try
            {
                _context.Add(card);
                int row = _context.SaveChanges();
                if(row == 0)
                    throw new Exception("No rows affected");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeactivateCard(CardModel card)
        {
            try
            {
                card.IsActive = false;
                _context.Cards.Update(card);
                int rows = _context.SaveChanges();
                if (rows == 0)
                    throw new Exception("No rows affected");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public CardModel? DeactivateStamper(CardModel card)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardModel> GetAllCards()
        {
            return _context.Cards;
        }

        public IEnumerable<CardModel> GetAllStampers()
        {
            throw new NotImplementedException();
        }

        public CardModel? GetCard(string id)
        {
            return _context.Cards.Find(id);
        }

        public bool UpdateStamper(CardModel card)
        {
            try
            {
                _context.Cards.Update(card);
                int rows = _context.SaveChanges();
                if (rows == 0)
                    throw new Exception("No rows affected");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        CardModel ICardRepository.UpdateStamper(CardModel card)
        {
            throw new NotImplementedException();
        }
    }
}
