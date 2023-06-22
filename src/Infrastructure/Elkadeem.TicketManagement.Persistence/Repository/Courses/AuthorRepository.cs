using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using Elkadeem.TicketManagement.Domain.Courses;
using Elkadeem.TicketManagement.Persistence.DbContexts;

namespace Elkadeem.TicketManagement.Persistence.Repository.Courses
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly IBaseDbContext _dbContext;

        public AuthorRepository(IBaseDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
