namespace Elkadeem.TicketManagement.Application.Extensions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {

        }
    }
}
