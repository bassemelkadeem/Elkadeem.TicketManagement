namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        int Save();

        Task<int> SaveAsync();
    }
}
