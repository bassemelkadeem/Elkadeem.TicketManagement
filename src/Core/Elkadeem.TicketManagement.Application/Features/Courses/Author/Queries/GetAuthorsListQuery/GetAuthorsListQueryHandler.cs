using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Author.Queries.GetAuthorsListQuery
{
    public class GetAuthorsListQueryHandler : IRequestHandler<GetAuthorsListQuery, List<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorsListQueryHandler(
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AuthorDto>> Handle(GetAuthorsListQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
        }
    }
}
