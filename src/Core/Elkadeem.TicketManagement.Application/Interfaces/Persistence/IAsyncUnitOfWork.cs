namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence
{
    public interface IAsyncUnitOfWork
    {
        Task SaveAsync();
    }
}
