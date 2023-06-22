using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Author.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
