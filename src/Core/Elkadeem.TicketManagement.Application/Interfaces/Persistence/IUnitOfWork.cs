namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        void Save();

        Task SaveAsync();
    }
}
