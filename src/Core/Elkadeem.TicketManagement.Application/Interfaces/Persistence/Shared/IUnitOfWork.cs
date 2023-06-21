namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared
{
    public interface IUnitOfWork
    {
        int Save();

        Task<int> SaveAsync();
    }
}
