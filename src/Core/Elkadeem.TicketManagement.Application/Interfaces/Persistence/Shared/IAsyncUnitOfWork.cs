namespace Elkadeem.TicketManagement.Application.Interfaces.Persistence.Shared
{
    public interface IAsyncUnitOfWork
    {
        Task SaveAsync();
    }
}
