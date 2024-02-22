namespace TimeStampMVC.Repository
{
    public interface IOpenDoorRepository
    {
        Task<bool> OpenDoorApiCallAsync();
    }
}
