using TimeStampLibary.Models;

namespace TimeStampMVC.Repository
{
    public interface ICardRepository
    {
        IEnumerable<CardModel> GetAllStampers();
        bool AddCard(CardModel card);
        CardModel? GetCard(string id);
        CardModel UpdateStamper(CardModel card);
        CardModel? DeactivateStamper(CardModel card);
    }
}
